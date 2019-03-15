using System.Threading.Tasks;
using GA.XYZ.LeT.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace GA.XYZ.LeT.Site.ViewComponents {

    public class SummaryViewComponent : ViewComponent{

        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public SummaryViewComponent(IDomainNotificationHandler<DomainNotification> notifications) {
            this._notifications = notifications;
        }

        public async Task<IViewComponentResult> InvokeAsync() {
            var notifications = await Task.FromResult(_notifications.GetNotifications());

            notifications.ForEach(x => ViewData.ModelState.AddModelError(string.Empty, x.Value));

            return View();
        }

    }
}
