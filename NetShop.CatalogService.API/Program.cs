using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NetShop.CatalogService.Application.Mappings;
using NetShop.CatalogService.Application.Validators;
using NetShop.CatalogService.Infrastructure.Messaging;
using NetShop.CatalogService.Infrastructure.Persistence.Data;
using NetShop.CatalogService.Infrastructure.Persistence.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Registra o MediatR (varre a assembly dos Handlers)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

// Registra o Automapper e adiciona os perfis de mapeamento
builder.Services.AddAutoMapper(typeof(CatalogMappingProfile));

// Registra o FluentValidation (pode ser integrado com o ASP.NET Core)
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductCommandValidator>();

// Registra os repositórios
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

// Registra o Event Publisher (para simulação)
builder.Services.AddSingleton<IEventPublisher, SimpleEventPublisher>();

builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
