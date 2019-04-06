using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Initium.Abstractions;

namespace Initium.Attributes
{

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RunNowAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Runs the job now.
        /// </summary>
        public RunNowAttribute()
        {
            
        }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class RunOnceInAttribute : Attribute, IAttribute
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
    public sealed class RunOnceAtAttribute : Attribute, IAttribute
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
    public sealed class RunEveryAttribute : Attribute, IAttribute
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
    public sealed class RunEveryAtAttribute : Attribute, IAttribute
    {
        /// <summary>
        /// Runs the job every according to the given interval and period at the given time.
        /// </summary>
        /// <param name="period"></param>
        /// <param name="hours">The hours (0 through 23).</param>
        /// <param name="minutes">The minutes (0 through 59).</param>
        /// <param name="interval">The interval</param>
        public RunEveryAtAttribute(int interval, Period period, int hours, int minutes)
        {
            Interval = interval;
            Period = period;
            Hour = hours;
            Minute = minutes;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }

        public int Interval { get; set; }

        public Period Period { get; set; }
        
    }


    public enum Period
    {

        Second,
        Minute,
        Hour,
        Day,
        Month
   
    }
}
