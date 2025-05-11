using DataManagement.Domain.AggregatesModel;

namespace DataManagement.Application.Interfaces
{
    public interface IRecordsRepository : IRepository<DataRecord, Guid>
    {
    }
}
