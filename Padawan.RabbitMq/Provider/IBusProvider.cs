using MassTransit;

namespace Padawan.RabbitMq.Provider
{
    public interface IBusProvider
    {
        IBusControl GetInstance(string instanceName = null);
    }
}
