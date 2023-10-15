using Microsoft.AspNetCore.Mvc;
using ProcessHub.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProcessHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private IProcessService _taskService;

        public TaskManagerController(IProcessService tasksService)
        {
            _taskService = tasksService;
        }

        // POST api/<TaskManagerController>
        [HttpPost("Initiate")]
        public ActionResult<int> InitiateTask([FromBody] string name)
        {
            return _taskService.InitiateProcess(name);
        }

        // POST api/<TaskManagerController>/Cancel/TaskHash
        [HttpPost("Cancel/{taskHash}")]
        public void CancelTask(int taskHash)
        {
            _taskService.CancelProcess(taskHash);
        }

        // POST api/<TaskManagerController>/Run/TaskHash
        [HttpPost("Run/{taskHash}")]
        public void RunTask(int taskHash) 
        {
            _taskService.RunProcess(taskHash);
        }
    }
}
