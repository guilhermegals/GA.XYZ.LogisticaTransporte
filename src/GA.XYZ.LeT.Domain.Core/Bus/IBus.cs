using GA.XYZ.LeT.Domain.Core.Commands;
using GA.XYZ.LeT.Domain.Core.Events;

namespace GA.XYZ.LeT.Domain.Core.Bus {

    public interface IBus{

        void SendCommand<T>(T aCommand) where T : Command;

        void RaiseEvent<T>(T aEvent) where T : Event;

    }
}
