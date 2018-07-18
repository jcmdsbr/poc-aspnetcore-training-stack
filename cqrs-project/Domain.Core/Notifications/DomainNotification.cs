using System;
using Domain.Core.Events;
using Domain.Entities.Fixed;

namespace Domain.Core.Notifications
{
    public class DomainNotification : Event
    {
        public DomainNotification(string key, string value, StatusNotification status = StatusNotification.Failure)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
            Status = status;
        }

        public Guid DomainNotificationId { get; }
        public string Key { get; }
        public string Value { get; }
        public int Version { get; }

        public StatusNotification Status { get; }
    }
}