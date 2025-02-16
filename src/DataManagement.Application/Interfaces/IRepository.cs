namespace DataManagement.Application.Interfaces
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
