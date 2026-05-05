using HortiFrutiStore.Application.Services;
using HortiFrutiStore.Application.Services.Interfaces;
using HortiFrutiStore.Domain.Interfaces;
using HortiFrutiStore.Infrastructure.Contexts;
using HortiFrutiStore.Infrastructure.Mappings;
using HortiFrutiStore.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HortiFruti Store API",
        Version = "v1",
        Description = "API para gerenciamento de produtos e pedidos da HortiFruti Store."
    });
});

builder.Services.AddTransient<IProdutoService, ProdutoService>();
builder.Services.AdicionarInfrastrutura();

builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler("/error");

app.UseAuthorization();

app.MapControllers();

app.Run();
