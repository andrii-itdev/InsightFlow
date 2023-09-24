using Microsoft.AspNetCore.Mvc;
using ProcessHub.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProcessHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private ITasksService _taskService;

        public TaskManagerController(ITasksService tasksService)
        {
            _taskService = tasksService;
        }

        // POST api/<TaskManagerController>
        [HttpPost]
        public void InitiateTask([FromBody] string name)
        {
            _taskService.InitiateTask(name);
        }

        // POST api/<TaskManagerController>/TaskHash
        [HttpPost("{taskHash}")]
        public void CancelTask(int taskHash)
        {
            _taskService.CancelTask(taskHash);
        }
    }
}
