using Microsoft.EntityFrameworkCore;
using Travelport.AirportRegistration.Application.Interfaces;
using Travelport.AirportRegistration.Application.Services;
using Travelport.AirportRegistration.Infrastructure;
using Travelport.AirportRegistration.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAirportRepository, AirportRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
