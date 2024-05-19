using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Serilog;

using ProcessHub.Extensions;

const string appsettings = "appsettings.json";

try
{
    var builder = WebApplication.CreateBuilder(args);

    var services = builder.Services;

    var configuration = new ConfigurationBuilder().AddJsonFile(appsettings).Build();

    // Adding logging mechanism
    var loggingConfig = new LoggerConfiguration().ReadFrom.Configuration(configuration);
    Log.Logger = loggingConfig.CreateLogger();
    services.AddSerilog(Log.Logger);

    // Add services to the container.
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

    services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    services.AddApplicationServices();
    services.AddRedisCache(builder.Configuration);

    services.AddMediatR(mediatrServiceConfiguration =>
    {
        // Registering all command handlers (classes that implement IRequestHandler<TRequest, TResponse>)
        mediatrServiceConfiguration.RegisterServicesFromAssemblyContaining(typeof(Program));
    });

    Log.Debug("Building the application.");

    var app = builder.Build();

    Log.Debug("The application is built.");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    Log.Debug("Running the application.");

    app.Run();
}
catch(Exception fatalException)
{
    Log.Fatal(fatalException, "Exception occurred. Terminating the application.");
}
finally
{
    Log.CloseAndFlush();
}
