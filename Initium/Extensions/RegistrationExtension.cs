using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Initium.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Initium.Extensions
{
   public static class RegistrationExtension
    {



        public static void RegisterAttributes(this IServiceCollection serviceCollection)
        {
            
            serviceCollection.Scan(
                selector =>
                selector.FromAssemblies().AddClasses(
                        x => x.WithAttribute<SingletonAttribute>()
                        )
                    .AsImplementedInterfaces()
                    .WithSingletonLifetime()
                );

            serviceCollection.Scan(
                selector =>
                    selector.FromAssemblies().AddClasses(
                            x => x.WithAttribute<ScopedAttribute>()
                        )
                        .AsImplementedInterfaces()
                        .WithScopedLifetime()
            );


            serviceCollection.Scan(
                selector =>
                    selector.FromAssemblies().AddClasses(
                            x => x.WithAttribute<TransientAttribute>()
                        )
                        .AsImplementedInterfaces()
                        .WithTransientLifetime()
            );




        }
        
        public static void ConfigurationAttributes(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            var configurationTypes = serviceCollection.Scan(
                selector =>
                    selector.FromAssemblies().AddClasses(
                        x => x.WithAttribute<ConfigurationAttribute>()
                    )
            ).Select(s => s.ServiceType);


            foreach (var configurationType in configurationTypes)
            {
                var attribute = configurationType.GetCustomAttribute<ConfigurationAttribute>();
                if (attribute != null)
                {
                    var instance = Activator.CreateInstance(configurationType);

                    configuration.Bind(attribute.Section, instance);
                }

            }
        }

    }
    }
