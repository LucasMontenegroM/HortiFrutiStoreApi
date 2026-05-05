using HortiFrutiStore.Domain.Interfaces;
using HortiFrutiStore.Infrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace HortiFrutiStore.Infrastructure.Repositories;

public static class InjecaoDeDepencencia
{
    public static IServiceCollection AdicionarInfrastrutura(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        return services;
    }
}
