using System;
using GA.XYZ.LeT.Domain.Core.Events;

namespace GA.XYZ.LeT.Domain.Core.Commands {

    public class Command : Message{

        public DateTime Timestamp { get; private set; }


        public Command() {
            Timestamp = DateTime.Now;
        }

    }
}
