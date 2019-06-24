using System.Collections.Generic;
using System.Linq;
using MassTransit;

namespace Padawan.RabbitMq.Provider
{
    public class BusProvider : IBusProvider
    {

        public BusProvider()
        {
            BusControls = new Dictionary<string, IBusControl>();
        }

        public Dictionary<string, IBusControl> BusControls { get; set; }


        internal void Add(string instanceName, IBusControl busControl)
        {
            BusControls.Add(instanceName,busControl);
        }

        public IBusControl GetInstance(string instanceName = null)
        {
            if (instanceName == null)
                return BusControls.Any() ? BusControls.FirstOrDefault().Value : null;

            // get specified bus
            return BusControls.ContainsKey(instanceName) ? BusControls.First(x => x.Key == instanceName).Value : null;
        }
    }
}
