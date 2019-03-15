using System.Collections.Generic;
using GA.XYZ.LeT.Domain.Core.Events;

namespace GA.XYZ.LeT.Domain.Core.Notifications {

    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message {

        bool HasNotification();

        List<T> GetNotifications();

    }
}
