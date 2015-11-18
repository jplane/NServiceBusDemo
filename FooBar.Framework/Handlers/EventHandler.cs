
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using FooBar.Common.Events;

namespace FooBar.Framework.Handlers
{
    public class EventHandler : IHandleMessages<Event>
    {
        public EventHandler()
        {
        }

        public IBus Bus { get; set; }

        public void Handle(Event evt)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext("JobsHub");

            if (evt is JobStartingEvent)
            {
                context.Clients.All.jobStarting(new
                {
                    id = ((JobStartingEvent) evt).Id,
                    name = ((JobStartingEvent) evt).Name
                });
            }
            else if (evt is JobStartedEvent)
            {
                context.Clients.All.jobStarted(new
                {
                    id = ((JobStartedEvent) evt).Id,
                    name = ((JobStartedEvent) evt).Name
                });
            }
            else if (evt is JobCompletedEvent)
            {
                context.Clients.All.jobCompleted(new
                {
                    id = ((JobCompletedEvent) evt).Id,
                    name = ((JobCompletedEvent) evt).Name
                });
            }
            else if (evt is JobStartFailedEvent)
            {
                context.Clients.All.jobStartFailed(new
                {
                    id = ((JobStartFailedEvent) evt).Id,
                    name = ((JobStartFailedEvent) evt).Name
                });
            }
            else if (evt is JobCanceledEvent)
            {
                context.Clients.All.jobCanceled(new
                {
                    id = ((JobCanceledEvent)evt).Id,
                    name = ((JobCanceledEvent)evt).Name
                });
            }
        }
    }
}
