
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NServiceBus;
using FooBar.Common.Commands;
using FooBar.Common.Messages;

namespace FooBar.JobEngine
{
    public class QueryHandler : IHandleMessages<ListJobInstancesQuery>,
                                IHandleMessages<ListJobTypesQuery>,
                                IHandleMessages<JobStatusQuery>
    {
        public QueryHandler()
        {
        }

        public IBus Bus { get; set; }

        public void Handle(ListJobInstancesQuery query)
        {
            var result = new ListJobInstancesQueryResult
            {
                Jobs = Engine.GetJobInstances().ToArray(),
                ConnectionId = query.ConnectionId
            };

            this.Bus.Reply(result);
        }

        public void Handle(ListJobTypesQuery query)
        {
        }

        public void Handle(JobStatusQuery query)
        {
        }
    }
}
