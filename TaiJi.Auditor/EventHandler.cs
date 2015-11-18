

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using TaiJi.Common.Events;

namespace TaiJi.Auditor
{
    public class EventHandler : IHandleMessages<Event>
    {
        public EventHandler()
        {
        }

        public IBus Bus { get; set; }

        public void Handle(Event message)
        {
            if (message is JobStartingEvent)
            {
                var msg = (JobStartingEvent) message;
                Console.WriteLine("Job '{0}' ({1}) starting...", msg.Name, msg.Id);
            }
            else if (message is JobStartedEvent)
            {
                var msg = (JobStartedEvent)message;
                Console.WriteLine("Job '{0}' ({1}) started...", msg.Name, msg.Id);
            }
            else if (message is JobStartFailedEvent)
            {
                var msg = (JobStartFailedEvent)message;
                Console.WriteLine("Job '{0}' ({1}) failed to start...", msg.Name, msg.Id);
            }
            else if (message is JobCompletedEvent)
            {
                var msg = (JobCompletedEvent)message;
                Console.WriteLine("Job '{0}' ({1}) completed...", msg.Name, msg.Id);
            }
            else if (message is JobCanceledEvent)
            {
                var msg = (JobCanceledEvent)message;
                Console.WriteLine("Job '{0}' ({1}) canceled...", msg.Name, msg.Id);
            }
        }
    }
}
