﻿using Padawan.Abstractions;
using Padawan.Attributes;
using Padawan.Sample.Web.Classes;

namespace Padawan.Sample.Web.Jobs
{
    public class SchedulerJob : ISchedulerJob
   {

       private readonly Apple _apple;

       public SchedulerJob(Apple apple)
       {
           _apple = apple;
       }


        [RunNow]
        [RunEvery(10,Period.Second)]
        [RunEveryDayAt(5,12,12)] 
        [RunOnceAt(10,24)]
        [RunOnceIn(10, Period.Hour)]
        public void Run()
        {
            System.Console.WriteLine("Job is fired");

            System.Console.WriteLine($"Dependecy value is {_apple.Value}");
        }

    }
}
