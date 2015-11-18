
using System;

namespace TaiJi.Common.Events
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
