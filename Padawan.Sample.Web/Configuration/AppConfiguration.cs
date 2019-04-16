using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Padawan.Attributes;

namespace Padawan.Sample.Web.Configuration
{
    [Configuration("AppConfiguration")]
    public class AppConfiguration
    {
        public string Say { get; set; }
    }
}
