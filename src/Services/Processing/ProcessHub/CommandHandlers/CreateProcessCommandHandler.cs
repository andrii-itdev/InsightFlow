using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;
    using Models;
    using Serilog;

    public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, ProcessDTO>
    {
        private readonly ILogger _logger;

        public CreateProcessCommandHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task<ProcessDTO> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            _logger.Verbose($"Handling {this.GetType().Name}");

            // Insert process into Redis Cache with a corresponding state
            return Task.FromResult<ProcessDTO>(new ProcessDTO());
        }
    }
}
