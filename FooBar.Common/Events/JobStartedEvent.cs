
using System;

namespace FooBar.Common.Events
{
    public class JobStartedEvent : Event
    {
        public JobStartedEvent()
        {
        }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
