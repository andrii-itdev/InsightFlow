using MediatR;

namespace DataManagement.API.Commands
{
    public record PostRecordCommand(string Data) : IRequest<bool>;
}
