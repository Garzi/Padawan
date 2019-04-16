using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Attributes;
using Padawan.Sample.Web.Classes;

namespace Padawan.Sample.Web.Classes
{
   [Singleton]
   public class Raspberry : IRaspberry
    {
        public string Value => "Raspberry";
    }
}
