using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost(nameof(AddJobToEnqueue))]
        public string AddJobToEnqueue(EnqueueDTO enqueueDTO)
        {
            return _TaskQueue.AddJobToEnqueue(enqueueDTO);
        }

        [HttpPost(nameof(AddOrUpdateJob))]
        public string AddOrUpdateJob(RecurringDTO recurringDTO)
        {
            return _TaskQueue.AddOrUpdateJob(recurringDTO);
        }

        [HttpGet]
        public Dictionary<int, string> GetAllCodeTasks()
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

        [HttpPost(nameof(GetJobsByCodeTasks))]
        public IEnumerable<HfJobDTO> GetJobsByCodeTasks(HfJobFilterDTO hfJobFilterDTO)
        {
            return _TaskQueue.GetJobsByCodeTasks(hfJobFilterDTO);
        }

        [HttpPost(nameof(GetJobsByDates))]
        public IEnumerable<HfJobDTO> GetJobsByDates(HfJobFilterDTO hfJobFilterDTO)
        {
            return _TaskQueue.GetJobsByDates(hfJobFilterDTO);
        }

        [HttpPost(nameof(GetJobsByPeriodJobIds))]
        public IEnumerable<HfJobDTO> GetJobsByPeriodJobIds(HfJobFilterDTO hfJobFilterDTO)
        {
            return _TaskQueue.GetJobsByPeriodJobIds(hfJobFilterDTO);
        }

        [HttpPost("RemoveJob/{JobId}")]
        public bool RemoveJob(string JobId)
        {
            return _TaskQueue.RemoveJob(JobId);
        }
    }
}