using DataManagement.Application.Interfaces;

namespace DataManagement.Infrastructure.Repositories
{
    internal class RecordsRepository : IRecordsRepository
    {
        public IUnitOfWork UnitOfWork { get => DataManagementContext; }
        public DataManagementContext DataManagementContext { get; }

        public RecordsRepository(DataManagementContext context)
        {
            DataManagementContext = context;
        }
    }
}
