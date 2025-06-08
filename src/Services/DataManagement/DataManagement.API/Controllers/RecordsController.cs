using DataManagement.API.Commands;
using DataManagement.API.Models;
using DataManagement.API.Resources;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics.CodeAnalysis;
using ILogger = Serilog.ILogger;

namespace DataManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordsController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IMediator mediator;
        private readonly IStringLocalizer<SharedResource> localizer;

        public RecordsController(ILogger logger, IMediator mediator, IStringLocalizer<SharedResource> localizer)
        {
            this.logger = logger;
            this.mediator = mediator;
            this.localizer = localizer;
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
            bool success = await mediator.Send(postRecord);

            if (!success)
            {
                string badRequestMsq = localizer[$"{nameof(RecordsController)}_{nameof(BadRequest)}"];
                return BadRequest(badRequestMsq);
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