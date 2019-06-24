using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MassTransit;

namespace Padawan.RabbitMq.Extensions
{
    public static class BusControlExtensions
    {



        #region Private Member of BusControlExtensions

        private static readonly Dictionary<string, ISendEndpoint> Endpoints = new Dictionary<string, ISendEndpoint>();
        private static readonly object SyncLock = new object();

        #endregion

        #region Public Methods of BusControlExtensions
        
        public static async Task Send<T>(this IBusControl busControl, T message, string queue) where T : class
        {
            if (Uri.TryCreate(busControl.Address, queue, out Uri endpointUri))
            {
                ISendEndpoint sendEndpoint;
                var key = endpointUri.ToString();

                lock (SyncLock)
                {
                    if (Endpoints.ContainsKey(key))
                    {
                        sendEndpoint = Endpoints[key];
                    }
                    else
                    {
                        sendEndpoint = busControl.GetSendEndpoint(endpointUri).Result;
                        Endpoints.Add(key, sendEndpoint);
                    }
                }

                await sendEndpoint.Send(message);
            }
            else
            {
                throw new ConfigurationException(
                    $"Cannot initialize a new Uri from these sources: Address:{busControl.Address} Queue:{queue}");
            }
        }
        #endregion

    }

}

