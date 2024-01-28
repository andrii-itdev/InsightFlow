using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;
    using Models;

    public class CancelProcessCommandHandler : IRequestHandler<CancelProcessCommand, ProcessDTO>
    {
        public Task<ProcessDTO> Handle(CancelProcessCommand request, CancellationToken cancellationToken)
        {
            // Change the state of the process in the redis cache to cancelled

            return Task.FromResult(new ProcessDTO());
        }
    }
}
