using MediatR;

namespace ProcessHub.API.Commands
{
    public class StartProcessCommand : IRequest<int>
    {
        public int Key { get; set; }

        public StartProcessCommand(int processKey)
        {
            Key = processKey;
        }
    }
}
