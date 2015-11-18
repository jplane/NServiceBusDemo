
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;

namespace FooBar.Common
{
    public class NServiceBusConventions : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure.Instance
                     .DefiningEventsAs(t => string.IsNullOrEmpty(t.Namespace) == false && t.Namespace == "FooBar.Common.Events")
                     .DefiningCommandsAs(t => string.IsNullOrEmpty(t.Namespace) == false && t.Namespace == "FooBar.Common.Commands")
                     .DefiningMessagesAs(t => string.IsNullOrEmpty(t.Namespace) == false && t.Namespace == "FooBar.Common.Messages");
        }
    }
}
