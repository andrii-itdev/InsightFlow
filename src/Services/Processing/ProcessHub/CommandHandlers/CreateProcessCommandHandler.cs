﻿using MediatR;

namespace ProcessHub.API.CommandHandlers
{
    using Commands;
    using Models;

    public class CreateProcessCommandHandler : IRequestHandler<CreateProcessCommand, ProcessDTO>
    {
        public Task<ProcessDTO> Handle(CreateProcessCommand request, CancellationToken cancellationToken)
        {
            // Insert process into Redis Cache with a corresponding state

            return Task.FromResult<ProcessDTO>(new ProcessDTO());
        }
    }
}
