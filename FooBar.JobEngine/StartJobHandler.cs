

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using FooBar.Common.Commands;
using FooBar.Common.Events;

namespace FooBar.JobEngine
{
    public class StartJobHandler : IHandleMessages<StartJobCommand>
    {
        public StartJobHandler()
        {
        }

        public IBus Bus { get; set; }

        public void Handle(StartJobCommand command)
        {
            Engine.StartJob(command, Bus);
        }
    }
}
