

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
  

// Register DI for all classes implement Interfaces provided by MediaR lib. If not (DI will not working with those class)
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationService<,>));
    config.AddOpenBehavior(typeof(LoggingService<,>));
});



// add Marten and UselightWeightSessions that mean you have manually store when need to update object. 
builder.Services.AddMarten(opts =>
{
    // ! notify for the compile time that ConnectionString can not be null.
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();

// Carter will find all classes implement ICarterModule to handle mapping by itself(Like using refelection to handle it) 
app.MapCarter();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(opts => { });
    app.UseHsts();
}


app.Run();
