using System;
using System.Collections.Generic;
using System.Text;
using Initium.Attributes;

namespace Initium.Sample.Console.Classes
{
   [Singleton]
   public class Raspberry : IRaspberry
    {
        public string Value => "Raspberry";
    }
}
