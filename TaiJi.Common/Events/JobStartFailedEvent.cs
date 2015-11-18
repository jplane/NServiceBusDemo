
using System;

namespace TaiJi.Common.Events
{
    public class JobStartFailedEvent : Event
    {
        public JobStartFailedEvent()
        {
        }

        public string Name { get; set; }

        public Guid Id { get; set; }
    }
}
