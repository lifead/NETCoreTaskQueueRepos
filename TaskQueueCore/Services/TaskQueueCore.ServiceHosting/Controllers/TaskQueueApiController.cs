using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskQueueCore.Domain;

namespace TaskQueueCore.ServiceHosting.Controllers
{
    [Route(WebAPI.TaskQueue)]
    [ApiController]
    public class TaskQueueApiController : ControllerBase
    {
    }
}