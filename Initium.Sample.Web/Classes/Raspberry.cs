using System;
using System.Collections.Generic;
using System.Text;
using Initium.Attributes;

namespace Initium.Sample.Console.Web
{
   [Singleton]
   public class Raspberry : IRaspberry
    {
        public string Value => "Raspberry";
    }
}
