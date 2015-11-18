

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using FooBar.Common.Commands;

namespace FooBar.JobEngine
{
    public class CancelJobHandler : IHandleMessages<CancelJobCommand>
    {
        public CancelJobHandler()
        {
        }

        public IBus Bus { get; set; }

        public void Handle(CancelJobCommand cmd)
        {
            Engine.CancelJob(cmd);
        }
    }
}
