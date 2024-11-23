using BicycleRent.Domain;
using BicycleRent.Domain.Contexts;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Domain.Repositories;
using BicycleRent.Server;
using BicycleRent.Server.Dto;
using BicycleRent.Server.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<BicycleRentContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 30))
    ));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<BicycleRepository>();
builder.Services.AddScoped<BicycleTypeRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<RentalRepository>();

builder.Services.AddScoped<BicycleService>();
builder.Services.AddScoped<BicycleTypeService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<RentalService>();


builder.Services.AddAutoMapper(typeof(Mapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
