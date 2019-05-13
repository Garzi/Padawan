using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Attributes;
using Padawan.Sample.Console.Classes;

namespace Padawan.Sample.Console
{
    [Singleton]
   public class App
    {

        private readonly Apple _apple;
        private readonly Banana _banana;
        private readonly IRaspberry _raspberry;
        private readonly Pear _pear;

        public App(Apple apple, Banana banana, IRaspberry raspberry, Pear pear)
        {
            _apple = apple;
            _banana = banana;
            _raspberry = raspberry;
            _pear = pear;
        }


        public void Run()
        {

            System.Console.WriteLine($"Apple is resolved, value is {_apple.Value}");
            System.Console.WriteLine($"Banana is resolved, value is {_banana.Value}");
            System.Console.WriteLine($"Raspberry is resolved, value is {_raspberry.Value}");
            System.Console.WriteLine($"Pear is resolved, value is {_pear.Value}");


        }
    }
}
