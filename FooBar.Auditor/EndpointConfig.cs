
using NServiceBus.Persistence.NHibernate;
using FooBar.Common.Commands;
using FooBar.Common.Events;
using FooBar.Common.Messages;
using NServiceBus;

namespace FooBar.Auditor
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
