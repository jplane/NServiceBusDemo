

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using TaiJi.Common.Commands;
using TaiJi.Common.Events;

namespace TaiJi.JobEngine
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
