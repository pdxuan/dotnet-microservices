

using BasketAPI.Repository;
using BuildingBlocks.Exeptions;
using DiscountGrpc;
using DiscountGrpc.SDK;

var builder = WebApplication.CreateBuilder(args);


var assembly = typeof(Program).Assembly;
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationService<,>));
    config.AddOpenBehavior(typeof(LoggingService<,>));

});


//Data Services
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();


builder.Services.AddGrpcSdk(builder.Configuration["GrpcSettings:DiscountUrl"]!);

//Instead of register like this 
//builder.Services.AddScoped<IBasketRepository>(services => new CachedBasketRepository(new BasketRepository(services.GetRequiredService<IDocumentSession>()), 
//    services.GetRequiredService<IDistributedCache>()));
// use Scrutor lib for readable code and easyly maintainable
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
    //options.InstanceName = "Basket";
});

builder.Services.AddHealthChecks().AddNpgSql(builder.Configuration
    .GetConnectionString("Database")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);


// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();
app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

app.Run();
