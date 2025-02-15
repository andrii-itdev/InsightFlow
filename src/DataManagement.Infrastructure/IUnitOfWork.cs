using System;
using System.Threading;
using System.Threading.Tasks;

namespace DataManagement.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        Task CommitAsync(CancellationToken cancellationToken);
        Task RollbackAsync(CancellationToken cancellationToken);
    }
}
