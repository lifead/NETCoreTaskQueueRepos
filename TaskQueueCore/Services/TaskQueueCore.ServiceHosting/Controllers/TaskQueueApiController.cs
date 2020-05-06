using Microsoft.AspNetCore.Mvc;
using TaskQueueCore.Domain;

namespace TaskQueueCore.ServiceHosting.Controllers
{
    [Route(WebAPI.TaskQueue)]
    [ApiController]
    public class TaskQueueApiController : ControllerBase
    {
        [HttpGet]
        public string GetAll()
        {
            return  string.Empty;
        }

    }
}