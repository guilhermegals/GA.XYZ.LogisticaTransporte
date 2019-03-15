using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GA.XYZ.LeT.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace GA.XYZ.LeT.Site.Controllers{

    public class BaseController : Controller{

        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications) {
            this._notifications = notifications;
        }

        protected bool OperacaoValida() {
            return (!_notifications.HasNotification());
        }

    }
}
