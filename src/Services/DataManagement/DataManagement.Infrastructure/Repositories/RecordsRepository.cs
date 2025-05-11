using DataManagement.Application.Interfaces;
using DataManagement.Domain.AggregatesModel;
using DataManagement.Infrastructure.Exceptions;
using MongoDB.Driver;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataManagement.Infrastructure.Repositories
{
    internal class RecordsRepository : IRecordsRepository
    {
        public DataManagementContext Context { get; }

        public RecordsRepository(DataManagementContext context)
        {
            Context = context;
        }

        private FilterDefinition<DataRecord> GetIdFilterDefinition(Guid id) => 
            Builders<DataRecord>.Filter.Eq(record => record.Id, id);

        private FilterDefinition<DataRecord> GetRecordIdFilterDefinition(DataRecord record) => 
            Builders<DataRecord>.Filter.Eq<DataRecord>(nameof(DataRecord.Id), record);

        private UpdateDefinition<DataRecord> GetUpdateDefinition(DataRecord record) => 
            Builders<DataRecord>.Update.Set(nameof(DataRecord.Data), record.Data);

        public async Task AddAsync(DataRecord record, CancellationToken cancellationToken)
        {
             await Context.RecordsCollection.InsertOneAsync(record, null, cancellationToken);
        }

        public async Task DeleteAsync(DataRecord record, CancellationToken cancellationToken)
        {
            var deleteResult = await Context.RecordsCollection.DeleteOneAsync(
                GetRecordIdFilterDefinition(record),
                null,
                cancellationToken);

            if (!deleteResult.IsAcknowledged)
            {
                throw new NoRecordsFoundException<Guid>(record.Id);
            }
        }

        public async Task UpdateAsync(DataRecord record, CancellationToken cancellationToken)
        {
            var updateResult = await Context.RecordsCollection.UpdateOneAsync(
                GetRecordIdFilterDefinition(record),
                GetUpdateDefinition(record),
                null,
                cancellationToken);

            if (!updateResult.IsAcknowledged)
            {
                throw new NoRecordsFoundException<Guid>(record.Id);
            }
        }

        public async Task<DataRecord> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var cursor = await Context.RecordsCollection.FindAsync(
                GetIdFilterDefinition(id),
                null,
                cancellationToken);

            if (!await cursor.AnyAsync())
            {
                throw new NoRecordsFoundException<Guid>(id);
            }

            return await cursor.FirstAsync(cancellationToken);
        }
    }
}
