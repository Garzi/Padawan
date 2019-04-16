using System;
using System.Collections.Generic;
using System.Text;
using Padawan.Attributes;

namespace Padawan.Sample.Web.Classes
{
    [Scoped]
    public class Pear
    {
        public string Value => "Pear";
    }
}
