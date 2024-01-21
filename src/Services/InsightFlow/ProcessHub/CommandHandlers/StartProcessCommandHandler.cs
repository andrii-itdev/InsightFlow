using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;

    public class StartProcessCommandHandler : IRequestHandler<StartProcessCommand, int>
    {
        public async Task<int> Handle(StartProcessCommand request, CancellationToken cancellationToken)
        {
            // Change the state of a process in the Redis Cache

            // Just a stub
            return await Task.FromResult(0);
        }
    }
}
