
using System;

namespace FooBar.Common.Events
{
    public class JobCompletedEvent : Event
    {
        public JobCompletedEvent()
        {
        }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
