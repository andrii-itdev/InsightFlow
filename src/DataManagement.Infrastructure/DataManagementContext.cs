using DataManagement.Application.Interfaces;
using DataManagement.Domain.AggregatesModel;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataManagement.Infrastructure
{
    internal class DataManagementContext : IUnitOfWork
    {
        private const string RecordsCollectionName = "Records";

        private readonly IMongoDatabase _database;
        private readonly IClientSessionHandle _sessionHandle;

        public IMongoCollection<DataRecord> RecordsCollection
        {
            get => _database.GetCollection<DataRecord>(RecordsCollectionName);
        }

        public DataManagementContext(IMongoClient mongoClient, string dbName)
        {
            _database = mongoClient.GetDatabase(dbName);
            _sessionHandle = mongoClient.StartSession();
        }

        public void BeginTransaction()
        {
            if (!_sessionHandle.IsInTransaction)
            {
                _sessionHandle.StartTransaction();
            }
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            if (!_sessionHandle.IsInTransaction)
            {
                return;
            }

            try
            {
                await _sessionHandle.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception)
            {
                await RollbackAsync(cancellationToken);
                throw;
            }
        }

        public async Task RollbackAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _sessionHandle.AbortTransactionAsync(cancellationToken);
            }
            finally
            {
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
            if (_sessionHandle.IsInTransaction)
            {
                _sessionHandle.AbortTransaction();
            }
            _sessionHandle.Dispose();
        }
    }
}
