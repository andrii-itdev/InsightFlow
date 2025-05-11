using DataManagement.Application.Interfaces;
using DataManagement.Application.Mappers;
using MediatR;

namespace DataManagement.API.Commands.Handlers
{
    public class PostRecordCommandHandler : IRequestHandler<PostRecordCommand, bool>
    {
        private IRecordsRepository RecordsRepository { get; init; }
        public IUnitOfWork UnitOfWork { get; init; }

        public PostRecordCommandHandler(IRecordsRepository recordsRepository, IUnitOfWork unitOfWork)
        {
            RecordsRepository = recordsRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(PostRecordCommand request, CancellationToken cancellationToken)
        {
            await UnitOfWork.BeginTransactionAsync(cancellationToken);
            await RecordsRepository.AddAsync(RecordsMapper.ToDataRecord(request), cancellationToken);
            return await UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}
