using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Attributes;

namespace Padawan.Sample.Console.Classes
{
   [Singleton]
   public class Raspberry : IRaspberry
    {

        public Raspberry()
        {
            Value = "Raspberry";
        }
        public string Value { get; set; } 
    }
}
