using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AtyService.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileSystemController : ControllerBase
    {
        [HttpPost]
        public ActionResult<object> SetupWatcher(string path, string filter, string notifyType = "LastWrite")
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.Join(Directory.GetCurrentDirectory(), path);

            object? notifyFilters = NotifyFilters.LastWrite;
            Enum.TryParse(typeof(NotifyFilters), notifyType, out notifyFilters);
            watcher.NotifyFilter = (NotifyFilters)(notifyFilters ?? NotifyFilters.LastWrite);
            watcher.Filter = filter;

            // Add event handlers
            watcher.Changed += Watcher_Changed;

            // Begin watching
            watcher.EnableRaisingEvents = true;

            return new { watcher.Path, watcher.NotifyFilter, watcher.Filter };
        }

        public ActionResult<object> SetupWebhook()
        {


            return new { Status = "Okay" };
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            HttpClient httpClient = new HttpClient();

        }
    }
}
