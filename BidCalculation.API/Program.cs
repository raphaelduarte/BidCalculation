using BidCalculation.Application.Factories;
using BidCalculation.Application.UseCases;
using BidCalculation.Domain.Repositories;
using BidCalculation.Domain.Strategies;
using BidCalculation.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IBidRepository, BidRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();

builder.Services.AddTransient<CommonVehicleFeeCalculator>();
builder.Services.AddTransient<LuxuryVehicleFeeCalculator>();

builder.Services.AddTransient<FeeCalculatorFactory>();

builder.Services.AddTransient<FeeCalculationUseCase>();


builder.Services.AddControllers();
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
