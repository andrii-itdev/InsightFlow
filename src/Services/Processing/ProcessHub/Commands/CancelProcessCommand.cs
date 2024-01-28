using MediatR;

namespace ProcessHub.API.Commands
{
    using Models;

    public class CancelProcessCommand : IRequest<ProcessDTO>
    {
        public int Key { get; set; }

        public CancelProcessCommand(int processHash)
        {
            Key = processHash;
        }
    }
}
