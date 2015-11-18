
using System;

namespace TaiJi.Common.Events
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
