using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskQueueCore.Domain;
using TaskQueueCore.Domain.DTO.TaskQueue;
using TaskQueueCore.Interfaces;
using TaskQueueCore.Services.TestTask;

namespace TaskQueueCore.ServiceHosting.Controllers
{
    [Route(WebAPI.TaskQueue)]
    [ApiController]
    public class TaskQueueApiController : ControllerBase, ITaskQueue
    {
        private readonly ITaskQueue _TaskQueue;

        public TaskQueueApiController(ITaskQueue TaskQueue)
        {
            _TaskQueue = TaskQueue;
        }

        [HttpPost(nameof(AddEnqueueJobAsync))]
        public async Task<string> AddEnqueueJobAsync(EnqueueDTO EnqueueDTO)
        {
            return await _TaskQueue.AddEnqueueJobAsync(EnqueueDTO);
        }


        [HttpPost(nameof(AddRecurringJobAsync))]
        public async Task<string> AddRecurringJobAsync(RecurringDTO RecurringDTO)
        {
            return await _TaskQueue.AddRecurringJobAsync(RecurringDTO);
        }


        [HttpPost("RemoveJob/{JobId}")]
        public async Task<bool> RemoveJobAsync(string JobId)
        {
            return await _TaskQueue.RemoveJobAsync(JobId);
        }

        [HttpGet]
        public IEnumerable<CodeTasks> GetAllCodeTasks()
        {
            return _TaskQueue.GetAllCodeTasks();
        }

        [HttpGet(nameof(GetAllJob))]
        public IEnumerable<HfJobDTO> GetAllJob()
        {
            return _TaskQueue.GetAllJob();
        }

        [HttpGet("{Id}")]
        public HfJobDTO GetJobByJobId(int Id)
        {
            return _TaskQueue.GetJobByJobId(Id);
        }
    }
}