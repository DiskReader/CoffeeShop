using CoffeeShop.Context;
using CoffeeShop.Interfaces.Services;
using CoffeeShop.Middlewares;
using CoffeeShop.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;
builder.Services.AddDbContext<CoffeeShopContext>(c => c.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICoffeeShopService, CoffeeShopService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();  

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
