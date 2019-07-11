using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using GreenPipes;
using GreenPipes.Internals.Extensions;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Padawan.Attributes;
using Padawan.RabbitMq.Attributes;
using Padawan.RabbitMq.Configuration;
using Padawan.RabbitMq.Exception;
using Padawan.RabbitMq.Provider;
using ConfigurationException = Padawan.RabbitMq.Exception.ConfigurationException;

namespace Padawan.RabbitMq.Extensions
{

    internal static class Extensions
    {
        #region Private Member of Extensions

        private static readonly BusProvider BusProvider = new BusProvider();
        
        #endregion

        #region Public Methods of Extensions

        public static void RegisterBusProvider(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddSingleton<IBusProvider>(BusProvider);

        }

        public static void RegisterConsumer(this IServiceCollection serviceCollection, string instanceName)
        {

            var consumerTypes = serviceCollection.Scan(
                selector =>
                    selector.FromApplicationDependencies().AddClasses(
                        x => x.WithAttribute<ConsumerAttribute>()
                    )
            ).Select(s => s.ServiceType).ToList();

            foreach (var consumer in consumerTypes)
            {
                var attribute = consumer.GetCustomAttribute<ConsumerAttribute>();
                if (attribute != null && attribute.InstanceName == instanceName)
                {
                    serviceCollection.AddSingleton(consumer);
                }

            }

        }

        public static void ConfigureConsumer(this IApplicationBuilder builder, string instanceName)
        {
            var entryAssembly = Assembly.GetEntryAssembly();

            if (entryAssembly != null)
            {
                var consumerTypes = entryAssembly.DefinedTypes
                    .Where(x => x.HasAttribute<ConsumerAttribute>()).ToList();

                var consumerTypeList = consumerTypes.Select(s => new
                    {
                        Instance = s.GetCustomAttribute<ConsumerAttribute>()?.InstanceName,
                        Type = s.AsType()
                    })
                    .Where(w => !string.IsNullOrWhiteSpace(w.Instance) && w.Instance == instanceName).Select(s => s.Type).ToList();

                CreateBusControls(builder, consumerTypeList, instanceName);

            }
        }

        #endregion

        #region Private Methods of Extensions


        private static void CreateBusControls(IApplicationBuilder builder, List<Type> consumers, string instanceName)
        {

            var appLifetime = builder.ApplicationServices.GetService<IApplicationLifetime>();


            var configuration = builder.ApplicationServices.GetService<IConfiguration>();

            var configs = configuration.GetSection(instanceName).Get<RabbitMqConfiguration>();

            if (configs == null)
                throw new ConfigurationException($"Missing configurations section for '{instanceName}, please add configuration section on your application config file.'");

            // create consumer by using IBusControl
            var busControl = CreateBus(consumers, builder.ApplicationServices, configs, instanceName);

            BusProvider.Add(instanceName, busControl);

            // add application lifecycle
            appLifetime.ApplicationStarted.Register(() => { busControl.StartAsync(); });

            appLifetime.ApplicationStopped.Register(() => { busControl.StopAsync(); });

        }

        private static IBusControl CreateBus(List<Type> consumerTypes, IServiceProvider provider, RabbitMqConfiguration configuration, string instanceName)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(configuration.Url), h =>
                {
                    h.Username(configuration.Username);
                    h.Password(configuration.Password);

                    if (configuration.Nodes != null && configuration.Nodes.Any())
                        h.UseCluster(cc => cc.ClusterMembers = configuration.Nodes);
                    
                    cfg.UseExtensionsLogging(provider.GetService<ILoggerFactory>());

                    if (configuration.RetryPolicy?.Incremental != null)
                        cfg.UseRetry(rp =>
                        {
                            rp.Incremental(
                                configuration.RetryPolicy.Incremental.RetryLimit,
                                configuration.RetryPolicy.Incremental.InitialInterval.FromMilliseconds(),
                                configuration.RetryPolicy.Incremental.IntervalIncrement.FromMilliseconds()
                            );
                        });
                    
                    if (configuration.DelayedExchangeMessageScheduler)
                        cfg.UseDelayedExchangeMessageScheduler();

                    if (configuration.ConcurrentMessageLimit > 0)
                        cfg.UseConcurrencyLimit(configuration.ConcurrentMessageLimit);

                    if (configuration.CircuitBreaker != null)
                        cfg.UseCircuitBreaker(cf =>
                        {
                            cf.TripThreshold = configuration.CircuitBreaker.TripThreshold;
                            cf.ActiveThreshold = configuration.CircuitBreaker.ActiveThreshold;
                            cf.ResetInterval = configuration.CircuitBreaker.ResetInterval.FromMinutes();
                            cf.TrackingPeriod = configuration.CircuitBreaker.TrackingPeriod.FromMinutes();
                        });

                    if (configuration.RateLimiter != null)
                        cfg.UseRateLimit(configuration.RateLimiter.RateLimit, configuration.RateLimiter.Interval.FromSeconds());

                });




                if (consumerTypes != null)
                {
                    foreach (var consumerType in consumerTypes)
                    {
                        var attribute = consumerType.GetCustomAttribute<ConsumerAttribute>();
                        if (attribute != null && attribute.InstanceName == instanceName)
                        {
                            cfg.ReceiveEndpoint(host, attribute.QueueName, configurator =>
                            {
                                // configure consumer options
                                if (attribute.PrefetchCount > 0)
                                    configurator.PrefetchCount = attribute.PrefetchCount;

                                if (!string.IsNullOrWhiteSpace(attribute.ExchangeName))
                                    configurator.Bind(attribute.ExchangeName);

                                if (attribute.ConcurrenyLimit > 0)
                                    configurator.UseConcurrencyLimit(attribute.ConcurrenyLimit);

                                if (attribute.ImmediateRetry > 0)
                                    configurator.UseRetry(retryConfigurator => { retryConfigurator.Immediate(attribute.ImmediateRetry); });

                                // add consumer
                                configurator.Consumer(consumerType, provider.GetService);

                            });
                        }
                    }
                }
            });

            return busControl;
        }

        private static TimeSpan FromMilliseconds(this int value)
        {
            return TimeSpan.FromMilliseconds(value);
        }
        private static TimeSpan FromSeconds(this int value)
        {
            return TimeSpan.FromSeconds(value);
        }

        private static TimeSpan FromMinutes(this int value)
        {
            return TimeSpan.FromMinutes(value);
        }

        #endregion
    }
}
