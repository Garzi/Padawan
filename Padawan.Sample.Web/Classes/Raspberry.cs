using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Attributes;

namespace Padawan.Sample.Console.Web
{
   [Singleton]
   public class Raspberry : IRaspberry
    {
        public string Value => "Raspberry";
    }
}
