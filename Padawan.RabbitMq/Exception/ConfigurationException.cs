using System;
using System.Collections.Generic;
using System.Text;

namespace Padawan.RabbitMq.Exception
{
   public class ConfigurationException : System.Exception
    {
        public ConfigurationException(string message) : base(message)
        {
           
        }
    }
}
