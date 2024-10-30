using BicycleRent.Domain;
using BicycleRent.Domain.Interfaces;
using BicycleRent.Domain.Repositories;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddSingleton<IRepository<Bicycle, string>, BicycleRepository>();
builder.Services.AddSingleton<IRepository<BicycleType, int>, BicycleTypeRepository>();
builder.Services.AddSingleton<IRepository<Customer, int>, CustomerRepository>();
builder.Services.AddSingleton<IRepository<Rental, int>, RentalRepository>();
builder.Services.AddAutoMapper(typeof(BicycleRent.Server.Mapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
