using MediatR;

namespace ProcessHub.API.Commands
{
    using Models;

    public class CreateProcessCommand : IRequest<ProcessDTO>
    {
        public string ProcessName { get; private set; }

        public CreateProcessCommand(string processName)
        {
            ProcessName = processName;
        }
    }
}
