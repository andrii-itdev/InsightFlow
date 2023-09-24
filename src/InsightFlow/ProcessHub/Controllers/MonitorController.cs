using Microsoft.AspNetCore.Mvc;

namespace ProcessHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        // GET: api/<MonitorController>
        [HttpGet]
        public string Get()
        {
            return nameof(MonitorController);
        }

        // GET api/<MonitorController>/tasks
        [HttpGet("Tasks")]
        public IEnumerable<string> GetTasks()
        {
            return new string[] { };
        }

        // GET: api/<MonitorController>/TaskHash/Details
        [HttpGet("Task/{taskHash}/Details")]
        public string GetDetails(int taskHash)
        {
            return $"Details For {taskHash}";
        }

        // GET: api/<MonitorController>/Status/TaskHash
        [HttpGet("Task/{taskHash}/Status")]
        public string GetStatus(int taskHash)
        {
            return $"Status For {taskHash}";
        }
    }
}
