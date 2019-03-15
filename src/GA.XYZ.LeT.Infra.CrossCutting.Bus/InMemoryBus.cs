using System;
using GA.XYZ.LeT.Domain.Core.Bus;
using GA.XYZ.LeT.Domain.Core.Commands;
using GA.XYZ.LeT.Domain.Core.Events;
using GA.XYZ.LeT.Domain.Core.Notifications;

namespace GA.XYZ.LeT.Infra.CrossCutting.Bus {

    public sealed class InMemoryBus : IBus {

        public static Func<IServiceProvider> ContainerAcessor { get; set; }
        private static IServiceProvider Container => ContainerAcessor();

        public void RaiseEvent<T>(T aEvent) where T : Event {
            Publish(aEvent);
        }

        public void SendCommand<T>(T aCommand) where T : Command {
            Publish(aCommand);
        }


        private static void Publish<T>(T message) where T : Message {
            if (Container == null)
                return;

            var obj = Container.GetService(message.MessageType.Equals("DomainNotification") ? typeof(IDomainNotificationHandler<T>) : typeof(IHandler<T>));

            ((IHandler<T>)obj).Handle(message);
        }
    }
}
