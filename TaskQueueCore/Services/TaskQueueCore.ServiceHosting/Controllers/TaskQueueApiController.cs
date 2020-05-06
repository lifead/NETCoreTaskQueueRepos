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


        public string AddJobToEnqueue(int CodeTask, DateTime AimDate, IEnumerable<int> objId)
        {
            return _TaskQueue.AddJobToEnqueue(CodeTask, AimDate, objId);
        }

        public string AddOrUpdateJob(string CronExpression, int CodeTask, string JobId = "", string queue = "default")
        {
            return _TaskQueue.AddOrUpdateJob(CronExpression, CodeTask, JobId, queue);
        }

        public Dictionary<int, string> GetAllCodeTasks()
        {
            return _TaskQueue.GetAllCodeTasks();
        }

        public IEnumerable<HfJobDTO> GetAllJob()
        {
            return _TaskQueue.GetAllJob();
        }

        public HfJobDTO GetJobByJobId(int Id)
        {
            return _TaskQueue.GetJobByJobId(Id);
        }

        public IEnumerable<HfJobDTO> GetJobsByCodeTasks(HfJobFilterDTO hfJobFilterDTO)
        {
            return _TaskQueue.GetJobsByCodeTasks(hfJobFilterDTO);
        }

        public IEnumerable<HfJobDTO> GetJobsByDates(HfJobFilterDTO hfJobFilterDTO)
        {
            return _TaskQueue.GetJobsByDates(hfJobFilterDTO);
        }

        public IEnumerable<HfJobDTO> GetJobsByPeriodJobIds(HfJobFilterDTO hfJobFilterDTO)
        {
            return _TaskQueue.GetJobsByPeriodJobIds(hfJobFilterDTO);
        }

        public bool RemoveJob(string JobId)
        {
            return _TaskQueue.RemoveJob(JobId);
        }
    }
}