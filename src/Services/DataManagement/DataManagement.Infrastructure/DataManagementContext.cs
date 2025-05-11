using Ardalis.GuardClauses;
using DataManagement.Application.Interfaces;
using DataManagement.Domain.AggregatesModel;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace DataManagement.Infrastructure
{
    internal class DataManagementContext : IUnitOfWork
    {
        private readonly IMongoDatabase Database;
        private readonly IMongoClient MongoClient;
        private IClientSessionHandle? SessionHandle { get; set; }

        public IMongoCollection<DataRecord> RecordsCollection
        {
            get => Database.GetCollection<DataRecord>(Constants.RecordsCollectionName);
        }

        public DataManagementContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(Constants.MongoDbConnection);
            var dbName = configuration.GetSection(Constants.MongoDbName).Value;

            Guard.Against.NullOrEmpty(connectionString, message: $"No ConnectionString defined for {Constants.MongoDbConnection}");
            Guard.Against.NullOrEmpty(dbName, message: $"No DatabaseName found in {Constants.MongoDbName}");

            var mongoClientSettings = new MongoClientSettings() { ConnectTimeout = new System.TimeSpan(0, 0, 1)  };
            MongoClient = new MongoClient(connectionString);
            Database = MongoClient.GetDatabase(dbName);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken)
        {
            try
            {
                SessionHandle = await MongoClient.StartSessionAsync(cancellationToken: cancellationToken);

                if (!SessionHandle.IsInTransaction)
                {
                    SessionHandle.StartTransaction();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            if (SessionHandle is null || !SessionHandle.IsInTransaction)
            {
                return false;
            }

            try
            {
                await SessionHandle.CommitTransactionAsync(cancellationToken);
                return true;
            }
            catch
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            if (SessionHandle is null || !SessionHandle.IsInTransaction)
            {
                return;
            }

            try
            {
                await SessionHandle.AbortTransactionAsync(cancellationToken);
            }
            catch
            {
                throw;
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await CommitAsync(cancellationToken);
        }


        ~DataManagementContext()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (SessionHandle is null)
            {
                return;
            }

            if (SessionHandle.IsInTransaction)
            {
                SessionHandle.AbortTransaction();
            }
            SessionHandle.Dispose();
        }
    }
}
