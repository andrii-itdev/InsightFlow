using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;
    using Models;

    public class CancelProcessCommandHandler : IRequestHandler<CancelProcessCommand, ProcessDTO>
    {
        public Task<ProcessDTO> Handle(CancelProcessCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new ProcessDTO());
        }
    }
}
