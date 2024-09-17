using Microsoft.OpenApi.Models;
using ProductService.Contacts;
using ProductService.Data;
using ProductService.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

builder.Services.AddSingleton<DapperContext>();
// Configure Dependency Injection for services and repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Configure Dapper with SQL Server
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product Service", Version = "v1" });
});

var app = builder.Build();


// Enable Swagger middleware
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Service v1");
});

app.Run();

