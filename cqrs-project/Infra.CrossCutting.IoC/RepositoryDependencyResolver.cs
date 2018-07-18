using Application.Repository;
using Infra.Repository.Context;
using Infra.Repository.Repository;
using Infra.Repository.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting.IoC
{
    internal class RepositoryDependencyResolver
    {
        public RepositoryDependencyResolver(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CustomerContext>();
        }
    }
}