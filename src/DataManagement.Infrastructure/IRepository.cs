namespace DataManagement.Infrastructure
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
