using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Attributes;

namespace Padawan.Sample.Web.Classes
{
    [Transient]
    public class Banana
    {
        public string Value => "Banana";
    }
}
