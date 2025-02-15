namespace DataManagement.Infrastructure.Repositories
{
    public class RecordsRepository : IRepository
    {
        public IUnitOfWork UnitOfWork { get => DataManagementContext; }
        public DataManagementContext DataManagementContext { get; }

        public RecordsRepository(DataManagementContext context)
        {
            DataManagementContext = context;
        }
    }
}
