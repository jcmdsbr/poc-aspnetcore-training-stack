using Application.Bus;
using Application.Domain;
using Domain.Core.Notifications;
using Domain.Customer.CommandHandlers;
using Domain.Customer.Commands;
using Domain.Customer.Queue;
using Infra.CrossCutting.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    internal class DomainDependecyResolver
    {
        public DomainDependecyResolver(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<NewCustomerCommand>, NewCustomerCommandHandler>();

            // Domain - Queue
            services.AddScoped<ICustomerCommandQueue, CustomerCommandQueue>();
        }
    }
}