
using System;

namespace FooBar.Common.Messages
{
    public class JobStatusQueryResult : Message
    {
        public JobStatusQueryResult()
        {
        }

        public Guid Id { get; set; }

        public Job Job { get; set; }

        public bool Found
        {
            get { return this.Job != null; }
        }
    }
}
