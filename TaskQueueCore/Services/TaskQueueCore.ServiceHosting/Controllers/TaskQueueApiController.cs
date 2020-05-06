using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskQueueCore.ServiceHosting.Controllers
{
    [Route(WebAPI.TaskQueue)]
    [ApiController]
    public class TaskQueueApiController : ControllerBase
    {
        private const object WebAPI;
    }
}