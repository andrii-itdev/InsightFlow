using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;
    using Serilog;

    public class StartProcessCommandHandler : IRequestHandler<StartProcessCommand, int>
    {
        private readonly ILogger _logger;

        public StartProcessCommandHandler(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<int> Handle(StartProcessCommand request, CancellationToken cancellationToken)
        {
            _logger.Verbose($"Handling {this.GetType().Name}");

            // Change the state of a process in the Redis Cache

            // Just a stub
            return await Task.FromResult(0);
        }
    }
}
