using MediatR;

namespace DataManagement.API.Commands.Handlers
{
    public class PostRecordCommandHandler : IRequestHandler<PostRecordCommand, bool>
    {
        public Task<bool> Handle(PostRecordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
