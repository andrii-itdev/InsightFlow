using ProcessHub.API.Models;
using StackExchange.Redis;

namespace ProcessHub.API.Repositories
{
    internal interface IProcessesRedisRepository : Infrastructure.IRepository<ProcessDTO>
    {
        Task<IEnumerable<ProcessDTO>> GetAll();
    }

    internal class ProcessesRedisRepository : IProcessesRedisRepository
    {
        const string ScanCommand = "SCAN";

        private readonly IDatabase Database;

        public ProcessesRedisRepository(ConnectionMultiplexer connectionMultiplexer)
        {
            this.Database = connectionMultiplexer.GetDatabase();
        }

        public async Task<IEnumerable<ProcessDTO>> GetAll()
        {
            // Just a stub
            var result = new List<ProcessDTO> {
                    new ProcessDTO(),
                    new ProcessDTO(),
                    new ProcessDTO()
            };
            return await Task.FromResult(result);
        }
    }
}
