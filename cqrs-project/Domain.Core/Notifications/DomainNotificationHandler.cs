using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities.Fixed;
using MediatR;

namespace Domain.Core.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        protected virtual IEnumerable<DomainNotification> Notifications => _notifications;

        public virtual bool HasNotificationsFailure =>
            Notifications.Any(x => x.Status != StatusNotification.Success);

        public virtual string GetMessageSuccess =>
            Notifications.FirstOrDefault(x => x.Status == StatusNotification.Success)?.Value;

        public virtual string GetDomainNotifications => string.Join(",",
            Notifications.Select(x => x.Value));

        public async Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
        }

        public void Dispose()
        {
            _notifications = new List<DomainNotification>();
        }
    }
}