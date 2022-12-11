using Microsoft.EntityFrameworkCore;
using Shipping.Data;
using Shipping.Infra.Repositories;
using Shipping.Services.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ShippingContext>(options => options.UseSqlServer("name=ConnectionStrings:db"));

builder.Services.AddTransient<IShipmentService, ShipmentService>();
builder.Services.AddTransient<IShipmentRepository, ShipmentRepository>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IServiceRepository, ServiceRepository>();

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
