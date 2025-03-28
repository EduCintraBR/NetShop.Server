using Microsoft.AspNetCore.Builder;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetShop.OrderService.Application.Interfaces;
using NetShop.OrderService.Application.Mappings;
using NetShop.OrderService.Infrastructure.Persistence.Data;
using NetShop.OrderService.Infrastructure.Persistence.Repositories;
using System.Reflection;
using NetShop.OrderService.Application.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
builder.Services.AddAutoMapper(typeof(OrderMappingProfile));
builder.Services.AddValidatorsFromAssemblyContaining<CreateOrderCommandValidator>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddDbContext<OrderDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("OrderDb")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
