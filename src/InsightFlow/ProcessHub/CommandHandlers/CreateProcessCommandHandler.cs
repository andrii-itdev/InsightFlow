using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;
    using Models;

    public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, ProcessDTO>
    {
        public Task<ProcessDTO> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult<ProcessDTO>(new ProcessDTO());
        }
    }
}
