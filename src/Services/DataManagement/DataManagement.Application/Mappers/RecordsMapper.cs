using DataManagement.API.Commands;
using DataManagement.Domain.AggregatesModel;

namespace DataManagement.Application.Mappers
{
    public static class RecordsMapper
    {
        public static DataRecord ToDataRecord(PostRecordCommand postRecordCommand)
        {
            return new DataRecord { Id = Guid.NewGuid(), Data = postRecordCommand.Data };
        }
    }
}
