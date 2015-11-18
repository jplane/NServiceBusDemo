
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using NHibernate.Cfg.XmlHbmBinding;
using NServiceBus;
using TaiJi.Common;
using TaiJi.Common.Commands;
using TaiJi.Common.Messages;

namespace TaiJi.Framework.Handlers
{
    public class QueryResultHandler : IHandleMessages<ListJobInstancesQueryResult>,
                                      IHandleMessages<ListJobTypesQueryResult>,
                                      IHandleMessages<JobStatusQueryResult>
    {
        public QueryResultHandler()
        {
        }

        public void Handle(ListJobInstancesQueryResult result)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext("JobsHub");

            context.Clients.Client(result.ConnectionId).listJobInstancesQueryResults(new
            {
                jobs = result.Jobs.OrderBy(job => job.Started).Select(job => new
                {
                    id = job.Id,
                    name = job.Name,
                    payload = job.Payload,
                    status = job.Status.ToString(),
                    started = job.Started,
                    duration = job.Duration
                }).ToArray()
            });
        }

        public void Handle(ListJobTypesQueryResult result)
        {
        }

        public void Handle(JobStatusQueryResult result)
        {
        }
    }
}
