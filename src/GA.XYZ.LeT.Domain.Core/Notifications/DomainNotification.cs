using System;
using GA.XYZ.LeT.Domain.Core.Events;

namespace GA.XYZ.LeT.Domain.Core.Notifications {

    public class DomainNotification : Event{

        public Guid DomainNotificationId { get; private set; }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public string Version { get; private set; }


        public DomainNotification(string aKey, string aValue) {
            DomainNotificationId = Guid.NewGuid();
            this.Key = aKey;
            this.Value = aValue;
        }

    }
}
