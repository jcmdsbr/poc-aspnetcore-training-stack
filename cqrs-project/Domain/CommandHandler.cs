using Application.Bus;
using Application.Repository;
using Domain.Core.Commands;
using Domain.Core.Notifications;
using Infra.CrossCutting.Shared.Messages;
using MediatR;

namespace Domain
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private readonly IUnitOfWork _uow;

        public CommandHandler(IUnitOfWork uow,
            IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler) notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
                _bus.RaiseEvent(
                    new DomainNotification(message.MessageType, error.ErrorMessage));
        }

        protected bool Commit()
        {
            if (_notifications.HasNotificationsFailure) return false;

            var commandResponse = _uow.Commit();

            if (commandResponse.Success) return true;

            _bus.RaiseEvent(
                new DomainNotification("Commit", SystemMessage.MsError));

            return false;
        }
    }
}