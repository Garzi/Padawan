using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Initium.Attributes;

namespace Initium.Sample.Web.Configuration
{
    [Configuration("AppConfiguration")]
    public class AppConfiguration
    {
        public string Say { get; set; }
    }
}
