using Infra.Contratos.Interfaces;
using Infra.Dapper;
using Infra.Factory;
using Infra.Interfaces.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyResolver
{
    public static class ConfigureDependencyInjection
    {
        public static void AddContainers(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ICarroDapper,CarroDapper>();
            services.AddTransient<IPessoaDapper,PessoaDapper>();
            services.AddSingleton<IConnectionFactory>(new ConnectionFactory(configuration["ConnectionStrings:DefaultConnection"]));
        }
    }
}