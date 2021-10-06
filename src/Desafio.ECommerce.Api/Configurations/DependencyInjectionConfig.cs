using Desafio.ECommerce.Business.Interfaces;
using Desafio.ECommerce.Business.Notificacoes;
using Desafio.ECommerce.Data.Context;
using Desafio.ECommerce.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Desafio.ECommerce.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<INotificador, Notificador>();
        }
    }
}