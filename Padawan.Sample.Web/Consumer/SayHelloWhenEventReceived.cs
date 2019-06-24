using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using Padawan.RabbitMq.Attributes;
using Padawan.Sample.Web.Consumer.Event;

namespace Padawan.Sample.Web.Consumer
{

    [Consumer(QueueName = "Test_Queue", ExchangeName = "Test_Exchange", PrefetchCount = 1)]
    public class SayHelloWhenEventReceived : IConsumer<EventMessage>
    {
        public Task Consume(ConsumeContext<EventMessage> context)
        {
            Console.WriteLine($"Hello {context.Message.Recipient}");

            return Task.CompletedTask;
        }
    }
}
