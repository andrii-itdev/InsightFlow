using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;

    public class StartProcessCommandHandler : IRequestHandler<StartProcessCommand, int>
    {
        public async Task<int> Handle(StartProcessCommand request, CancellationToken cancellationToken)
        {
            // Just a stub
            return await Task.FromResult(0);
        }
    }
}
