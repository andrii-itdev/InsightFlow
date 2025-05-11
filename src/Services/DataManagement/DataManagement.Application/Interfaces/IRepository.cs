using DataManagement.Domain.AggregatesModel;

namespace DataManagement.Application.Interfaces
{
    public interface IRepository<T, K>
    {
        Task AddAsync(T item, CancellationToken token);
        Task DeleteAsync(T item, CancellationToken token);
        Task UpdateAsync(T item, CancellationToken token);
        Task<T> GetAsync(K id, CancellationToken token);
    }
}
