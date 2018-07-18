using Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class BaseController : Controller
    {
        private readonly DomainNotificationHandler _notifications;

        public BaseController(INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler) notifications;
        }

        public bool IsValidOperation()
        {
            return !_notifications.HasNotificationsFailure;
        }

        public string GetMessageSuccess()
        {
            return _notifications.GetMessageSuccess;
        }

        public string GetNotifications()
        {
            return _notifications.GetDomainNotifications;
        }
    }
}