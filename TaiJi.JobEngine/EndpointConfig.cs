
using NServiceBus.Persistence.NHibernate;
using TaiJi.Common;
using TaiJi.Common.Commands;
using TaiJi.Common.Events;
using TaiJi.Common.Messages;
using NServiceBus;

namespace TaiJi.JobEngine
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Publisher, UsingTransport<SqlServer>
    {
    }

    class CustomInit : INeedInitialization
    {
        public void Init()
        {
            NHibernatePersistence.UseAsDefault();
        }
    }
}
