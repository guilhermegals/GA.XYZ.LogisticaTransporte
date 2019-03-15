using System;

namespace GA.XYZ.LeT.Domain.Core.Events {
    public abstract class Event : Message{

        public DateTime Timestamp { get; set; }

        public Event() {
            Timestamp = DateTime.Now;
        }

    }
}
