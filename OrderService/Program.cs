using Microsoft.OpenApi.Models;
using OrderService.Contacts;
using OrderService.Data;
using OrderService.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container
builder.Services.AddControllers();

builder.Services.AddSingleton<DapperContext>();
// Configure Dependency Injection for services and repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// Configure Dapper with SQL Server
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Service", Version = "v1" });
});

var app = builder.Build();


// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Service v1");
});

app.Run();