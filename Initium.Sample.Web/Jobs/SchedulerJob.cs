using System;
using System.Collections.Generic;
using System.Text;
using Initium.Abstractions;
using Initium.Attributes;

namespace Initium.Sample.Web.Jobs
{
   public class SchedulerJob : ISchedulerJob
    {


        [RunNow]
        [RunEvery(10,Period.Day)]
        [RunEveryAt(5,Period.Day,12,12)]
        [RunOnceAt(10,24)]
        [RunOnceIn(10, Period.Hour)]
        
        public void Run()
        {

        }

    }
}
