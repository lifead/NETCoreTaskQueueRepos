using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskQueueCore.Domain.DTO.TaskQueue;
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

        [HttpGet]
        public IActionResult AddEnqueue()
        {
            return View(new EnqueueDTO());
        }

        [HttpPost]
        public async Task<IActionResult> AddEnqueue(EnqueueDTO enqueueDTO)
        {
            string jobId = await _TaskQueue.AddEnqueueJobAsync(enqueueDTO);
            return Json(new { jobId = jobId });
        }


        [HttpGet]
        public IActionResult AddRecurring()
        {
            return View(new RecurringDTO());
        }

        [HttpPost]
        public async Task<IActionResult> AddRecurring(RecurringDTO recurringDTO)
        {
            string jobId = await _TaskQueue.AddRecurringJobAsync(recurringDTO);
            return Json(new { jobId = jobId });
        }

    }
}