
using NServiceBus.Persistence.NHibernate;
using FooBar.Common;
using FooBar.Common.Commands;
using FooBar.Common.Events;
using FooBar.Common.Messages;
using NServiceBus;

namespace FooBar.JobEngine
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
