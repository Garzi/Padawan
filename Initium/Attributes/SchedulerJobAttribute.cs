using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Initium.Abstractions;

namespace Initium.Attributes
{

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RunNowAttribute : Attribute, ISchedulerJobAttribute
    {
        /// <summary>
        /// Runs the job now.
        /// </summary>
        public RunNowAttribute()
        {
            
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RunOnceInAttribute : Attribute, ISchedulerJobAttribute
    {


        /// <summary>
        /// Runs the job once according to the given interval and period 
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="period"></param>
        public RunOnceInAttribute(int interval, Period period)
        {
            Interval = interval;
            Period = period;
        }

        public int Interval { get; set; }
        
        public Period Period { get; set; }
    }



    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RunOnceAtAttribute : Attribute, ISchedulerJobAttribute
    {

        /// <summary>
        /// Runs the job once at the given time.
        /// </summary>
        /// <param name="hours">The hours (0 through 23).</param>
        /// <param name="minutes">The minutes (0 through 59).</param>
        public RunOnceAtAttribute(int hours, int minutes)
        {
            Hour = hours;
            Minute = minutes;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }   
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RunEveryAttribute : Attribute, ISchedulerJobAttribute
    {

        /// <summary>
        /// Runs the job every according to the given interval and period 
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="period"></param>
        public RunEveryAttribute(int interval, Period period)
        {
            Interval = interval;
            Period = period;
        }

        public int Interval { get; set; }

        public Period Period { get; set; }
    }


    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RunEveryDayAtAttribute : Attribute, ISchedulerJobAttribute
    {
        /// <summary>
        /// Runs the job every day according to the given interval at the given time.
        /// </summary>
        /// <param name="hours">The hours (0 through 23).</param>
        /// <param name="minutes">The minutes (0 through 59).</param>
        /// <param name="interval">The interval</param>
        public RunEveryDayAtAttribute(int hours, int minutes, int interval)
        {
            Interval = interval;
            Hour = hours;
            Minute = minutes;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }

        public int Interval { get; set; }

        public Period Period => Period.Day;

    }


    public enum Period
    {

        Milliseconds,
        Second,
        Minute,
        Hour,
        Day,
        Month,
        Years,
        Weekdays

    }
}
