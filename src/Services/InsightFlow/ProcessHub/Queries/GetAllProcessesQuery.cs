using MediatR;
using ProcessHub.API.Models;
using ProcessHub.API.Repositories;

namespace ProcessHub.API.Queries
{
    internal class GetAllProcessesQuery : IRequest<IEnumerable<ProcessDTO>>
    {
    }

    internal class GetAllProcessesQueryHandler : IRequestHandler<GetAllProcessesQuery, IEnumerable<ProcessDTO>>
    {
        private readonly IProcessesRedisRepository processesRepository;

        public GetAllProcessesQueryHandler(IProcessesRedisRepository processesRepository)
        {
            this.processesRepository = processesRepository;
        }

        public async Task<IEnumerable<ProcessDTO>> Handle(GetAllProcessesQuery request, CancellationToken cancellationToken)
        {
            return await processesRepository.GetAll();
        }
    }
}
