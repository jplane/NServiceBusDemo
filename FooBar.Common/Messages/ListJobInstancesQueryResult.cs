
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace FooBar.Common.Messages
{
    public class ListJobInstancesQueryResult : Message
    {
        public ListJobInstancesQueryResult()
        {
        }

        public string ConnectionId { get; set; }

        public Job[] Jobs { get; set; }
    }
}
