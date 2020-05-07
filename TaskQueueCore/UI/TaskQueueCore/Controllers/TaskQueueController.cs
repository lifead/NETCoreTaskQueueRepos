using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskQueueCore.Interfaces;

namespace TaskQueueCore.Controllers
{
    public class TaskQueueController : Controller
    {
        private readonly ITaskQueue _TaskQueue;

        public TaskQueueController([FromServices] ITaskQueue TaskQueue)
        {
            _TaskQueue = TaskQueue;
        }

        public IActionResult Index()
        {
            var allJobs = _TaskQueue.GetAllJob();
            return View(allJobs);
        }
    }
}