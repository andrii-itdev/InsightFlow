using DataManagement.API.Commands;
using DataManagement.API.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using ILogger = Serilog.ILogger;

namespace DataManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public RecordsController(ILogger logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{recordId:guid}")]
        [ProducesResponseType(typeof(RecordResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetRecord([NotNull] Guid? recordId = null)
        {
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostRecord([FromBody] PostRecordCommand postRecord)
        {
            bool success = await _mediator.Send(postRecord);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route("{recordId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteRecord([NotNull] Guid recordId)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{recordId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateRecord([NotNull] Guid recordId)
        {
            return Ok();
        }
    }
}