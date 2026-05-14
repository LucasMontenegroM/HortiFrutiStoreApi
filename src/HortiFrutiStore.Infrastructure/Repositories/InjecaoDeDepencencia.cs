using FluentValidation;
using HortiFrutiStore.Application.Services;
using HortiFrutiStore.Application.Services.Interfaces;
using HortiFrutiStore.Domain.Entities;
using HortiFrutiStore.Domain.Interfaces;
using HortiFrutiStore.Infrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;
using static HortiFrutiStore.Domain.Entities.Produto;

namespace HortiFrutiStore.Infrastructure.Repositories;

public static class InjecaoDeDepencencia
{
    public static IServiceCollection AdicionarInfrastrutura(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IValidator<Produto>, ProdutoValidator>();
        services.AddTransient<IProdutoService, ProdutoService>();



        return services;
    }
}
