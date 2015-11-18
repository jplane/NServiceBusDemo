
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using NServiceBus;
using FooBar.Common.Commands;

namespace FooBar.Framework
{
    public class JobsHub : Hub
    {
        public JobsHub()
        {
        }

        public void StartJob(string type, string payload)
        {
            var cmd = new StartJobCommand
            {
                Name = type,
                Payload = payload
            };

            WebApiApplication.Bus.Send(cmd);
        }

        public void CancelJob(Guid id)
        {
            var cmd = new CancelJobCommand
            {
                Id = id
            };

            WebApiApplication.Bus.Send(cmd);
        }

        public void ListJobInstances()
        {
            var query = new ListJobInstancesQuery
            {
                ConnectionId = this.Context.ConnectionId
            };

            WebApiApplication.Bus.Send(query);
        }
    }
}
