using System;
using System.Collections.Generic;
using System.Text;

namespace Padawan.RabbitMq.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConsumerAttribute: Attribute
    {
        public string QueueName { get; set; }
        public string ExchangeName { get; set; }
        public ushort PrefetchCount { get; set; }
        public int ConcurrenyLimit { get; set; }
        public int ImmediateRetry { get; set; }

        /// <summary>
        /// Instance name must be equal with configuration section name, Default value is 'RabbitMq'
        /// </summary>
        public string InstanceName { get; set; } = "RabbitMq";
    }
}
