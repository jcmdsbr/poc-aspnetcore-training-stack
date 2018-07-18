using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Bus;
using Application.Repository;
using Domain.Core.Notifications;
using Domain.Customer.Commands;
using Domain.Entities.Fixed;
using Infra.CrossCutting.Shared.Messages;
using MediatR;
using Entity = Domain.Entities.Models;

namespace Domain.Customer.CommandHandlers
{
    public class NewCustomerCommandHandler : CommandHandler, INotificationHandler<NewCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediatorHandler Bus;

        public NewCustomerCommandHandler(
            ICustomerRepository customerRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;

            Bus = bus;
        }

        public async Task Handle(NewCustomerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var customer = new Entity.Customer(Guid.NewGuid(),
                message.Name, message.BirthDate,
                message.Email, message.Cpf);


            if (_customerRepository.GetByEmail(customer.Email) != null)
            {
                await Bus.RaiseEvent(
                    new DomainNotification(message.MessageType, SystemMessage.MsEmail));

                return;
            }

            _customerRepository.Add(customer);

            if (Commit())
                await Bus.RaiseEvent(
                    new DomainNotification(message.MessageType, SystemMessage.MsSuccess, StatusNotification.Success));
        }
    }
}