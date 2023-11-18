using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProcessHub.API.Commands;
using ProcessHub.API.Models;
using ProcessHub.API.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProcessHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessManagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProcessManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/<TaskManagerController>
        [HttpPost("Create/{name}")]
        public async Task<ActionResult<ProcessDTO>> CreateProcess([FromBody] string name)
        {
            return await _mediator.Send(new CreateProcessCommand(name));
        }

        // POST api/<TaskManagerController>/Cancel/TaskHash
        [HttpPost("Cancel/{processHash}")]
        public async Task CancelProcess(int processHash)
        {
            await _mediator.Send(new CancelProcessCommand(processHash));
        }

        // POST api/<TaskManagerController>/Run/TaskHash
        [HttpPost("Start/{processHash}")]
        public async Task StartProcess(int processHash) 
        {
            await _mediator.Send(new StartProcessCommand(processHash));
        }

        [HttpGet("Processes")]
        public async Task<ActionResult<IEnumerable<ProcessDTO>>> GetProcesses()
        {
            var result = await _mediator.Send(new GetAllProcessesQuery());
            return new ActionResult<IEnumerable<ProcessDTO>>(result);
        }
    }
}
