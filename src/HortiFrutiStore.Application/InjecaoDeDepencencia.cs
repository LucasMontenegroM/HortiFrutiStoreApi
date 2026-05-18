using HortiFrutiStore.Application.Services;
using HortiFrutiStore.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HortiFrutiStore.Application;

public static class InjecaoDeDepencencia
{
    public static IServiceCollection AdicionarApplication(this IServiceCollection services)
    {
        services.AddTransient<IProdutoService, ProdutoService>();

        return services;
    }
}
