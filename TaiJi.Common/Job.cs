using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaiJi.Common
{
    public class Job
    {
        public Job()
        {
        }

        public string Name { get; set; }

        public Guid Id { get; set; }

        public string Payload { get; set; }

        public JobStatus Status { get; set; }

        public DateTimeOffset? Started { get; set; }

        public TimeSpan? Duration { get; set; }
    }

    public enum JobStatus
    {
        NotStarted = 1,
        Starting,
        Started,
        Completed,
        Canceled,
        Faulted
    }
}
