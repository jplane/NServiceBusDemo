
using NServiceBus.Persistence.NHibernate;
using TaiJi.Common.Commands;
using TaiJi.Common.Events;
using TaiJi.Common.Messages;
using NServiceBus;

namespace TaiJi.Auditor
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<SqlServer>
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
