
using System;

namespace FooBar.Common.Events
{
    public class JobStartingEvent : Event
    {
        public JobStartingEvent()
        {
        }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
