using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;
    using Models;
    using Serilog;

    public class CancelProcessCommandHandler : IRequestHandler<CancelProcessCommand, ProcessDTO>
    {
        private readonly ILogger _logger;

        public CancelProcessCommandHandler(ILogger logger)
        {
            _logger = logger;
        }

        public Task<ProcessDTO> Handle(CancelProcessCommand request, CancellationToken cancellationToken)
        {
            _logger.Verbose($"Handling {this.GetType().Name}");

            // Change the state of the process in the redis cache to cancelled

            return Task.FromResult(new ProcessDTO());
        }
    }
}
