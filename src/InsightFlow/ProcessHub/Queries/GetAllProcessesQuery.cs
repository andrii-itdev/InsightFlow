using MediatR;
using Microsoft.EntityFrameworkCore;
using ProcessHub.API.Models;

namespace ProcessHub.API.Queries
{
    public class GetAllProcessesQuery : IRequest<IEnumerable<ProcessDTO>>
    {
    }

    public class GetAllProcessesQueryHandler : IRequestHandler<GetAllProcessesQuery, IEnumerable<ProcessDTO>>
    {
        public async Task<IEnumerable<ProcessDTO>> Handle(GetAllProcessesQuery request, CancellationToken cancellationToken)
        {
            // Just a stub
            var result = new List<ProcessDTO> {
                    new ProcessDTO(),
                    new ProcessDTO(),
                    new ProcessDTO()
            };
            return await Task.FromResult(result);
        }
    }
}
