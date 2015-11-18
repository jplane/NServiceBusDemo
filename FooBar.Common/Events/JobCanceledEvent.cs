
using System;

namespace FooBar.Common.Events
{
    public class JobCanceledEvent : Event
    {
        public JobCanceledEvent()
        {
        }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
