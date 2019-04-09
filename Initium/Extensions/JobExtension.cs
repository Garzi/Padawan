using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using FluentScheduler;
using Initium.Abstractions;
using Initium.Attributes;
using Microsoft.Extensions.DependencyInjection;

namespace Initium.Extensions
{
    internal static class JobExtension
    {

        public static IServiceProvider InitializeSchedulerJob(this IServiceProvider serviceProvider)
        {

            var entryAssembly = Assembly.GetEntryAssembly();

            var schedulerJobTypes = entryAssembly.DefinedTypes
                .Where(x => x.ImplementedInterfaces.Contains(typeof(ISchedulerJob))).ToList();

            foreach (var jobType in schedulerJobTypes)
            {
                var instance = serviceProvider.GetService(jobType);

                if (instance == null) continue;
                var methods = instance.GetType().GetMethods()
                    .Where(x => x.GetCustomAttributes(typeof(ISchedulerJobAttribute), true).Length > 0).ToList();
                
                if (!methods.Any()) continue;
                foreach (var method in methods)
                {
                    foreach (var attr in method.GetCustomAttributes())
                    {
                        attr.GetScheduleByAttributes(() => { method.Invoke(instance, null); });
                    }
                            
                }
                
            }

            return serviceProvider;
        }


        public static Action<Schedule> GetScheduleByAttributes(this Attribute attribute, Action job)
        {

            if (attribute is RunEveryAttribute runNow)
                JobManager.AddJob(job, schedule =>  schedule.ToRunNow());

            if (attribute is RunEveryAttribute runEvery)
                JobManager.AddJob(job, schedule => schedule.ToRunEvery(runEvery.Interval).Period(runEvery.Period));

            if (attribute is RunEveryDayAtAttribute runEveryAt)
                JobManager.AddJob(job, schedule => schedule.ToRunEvery(runEveryAt.Interval).Days().At(runEveryAt.Hour, runEveryAt.Minute));

            if (attribute is RunOnceAtAttribute runOnceAt)
                JobManager.AddJob(job, schedule => schedule.ToRunOnceAt(runOnceAt.Hour, runOnceAt.Minute));

            if (attribute is RunOnceInAttribute runOnceIn)
                JobManager.AddJob(job, schedule => schedule.ToRunOnceIn(runOnceIn.Interval).Period(runOnceIn.Period));

            
            return null;
        }

      
        private static object Period(this TimeUnit timeUnit, Period period)
        {
            switch (period)
            {
                case Attributes.Period.Day:
                    return timeUnit.Days();
                case Attributes.Period.Second:
                    return timeUnit.Seconds();
                case Attributes.Period.Minute:
                    return timeUnit.Minutes();
                case Attributes.Period.Hour:
                    return timeUnit.Hours();
                case Attributes.Period.Month:
                    return timeUnit.Months();
                case Attributes.Period.Milliseconds:
                    return timeUnit.Milliseconds();
                case Attributes.Period.Years:
                    return timeUnit.Years();
                case Attributes.Period.Weekdays:
                    return timeUnit.Weekdays();
                default:
                    throw new ArgumentOutOfRangeException(nameof(period), period, null);
            }
        }

    }
}
