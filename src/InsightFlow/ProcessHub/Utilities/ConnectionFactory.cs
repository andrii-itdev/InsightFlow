using CommunityToolkit.Diagnostics;
using StackExchange.Redis;

namespace Infrastructure.Utilities
{
    public class ConnectionFactory
    {
        const string RedisConnectionStringKey = "RedisConnectionString";

        public static ConnectionMultiplexer CreateConnection(IConfiguration configuration)
        {
            Guard.IsNotNull(configuration);

            string? connectionString = configuration.GetConnectionString(RedisConnectionStringKey);

            Guard.IsNotNull(connectionString);

            ConfigurationOptions connectionOptions = ConfigurationOptions.Parse(connectionString, true);

            return ConnectionMultiplexer.Connect(connectionOptions);
        }
    }
}
