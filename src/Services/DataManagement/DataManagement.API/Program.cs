
using DataManagement.API.Extensions;
using DataManagement.Infrastructure;
using Serilog;

const string appsettings = "appsettings.json";

try
{
    var builder = WebApplication.CreateBuilder(args);

    var services = builder.Services;

    var configuration = new ConfigurationBuilder().AddJsonFile(appsettings).Build();

    // Adding logging mechanism
    var loggingConfig = new LoggerConfiguration()
        .ReadFrom.Configuration(configuration)
        .WriteTo.Async(sinkConfig => sinkConfig.Debug());

    Log.Logger = loggingConfig.CreateLogger();
    services.AddSerilog(Log.Logger);

    // Add services to the container.

    builder.Services.AddMediatR(configuration =>
    {
        configuration.RegisterServicesFromAssemblyContaining(typeof(Program));
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddInfrastructureServices();


    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.AddMiddlewares();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception fatalException)
{
    Log.Fatal(fatalException, "Exception occurred. Terminating the application.");
}
finally
{
    Log.CloseAndFlush();
}