using OrderingAPI;
using OrderingApplication;
using OrderingInfrastructure;
using OrderingInfrastructure.Data.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseApiServices();


app.UseHttpsRedirection();


if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}


app.Run();
