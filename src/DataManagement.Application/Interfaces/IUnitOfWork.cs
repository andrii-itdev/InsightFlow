namespace DataManagement.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}
