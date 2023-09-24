using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProcessHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {

        // POST api/<TaskManagerController>
        [HttpPost]
        public void InitiateTask([FromBody] string name)
        {
        }

        // POST api/<TaskManagerController>/TaskHash
        [HttpPost("{taskHash}")]
        public void CancelTask(int taskHash)
        {
        }
    }
}
