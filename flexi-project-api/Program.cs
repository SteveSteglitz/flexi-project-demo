using CustomerModule.Application;
using CustomerModule.Domain.Interfaces;
using CustomerModule.Infrastructure;
using Microsoft.AspNetCore.Localization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Konfigurationsdatei laden
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // appsettings.json immer laden
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true) // appsettings.<EnvironmentName>.json laden, falls vorhanden
    .Build();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// Aktualisiere den Endpunkt in Program.cs
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Diese Zeile hinzufügen, um Controller zu verwenden
});

app.Run();

