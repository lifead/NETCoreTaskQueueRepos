using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using TaskQueueCore.Clients.Base;
using TaskQueueCore.Domain;
using TaskQueueCore.Domain.DTO.TaskQueue;
using TaskQueueCore.Interfaces;

namespace TaskQueueCore.Clients.TaskQueue
{
    public class TaskQueueClient : BaseClient, ITaskQueue
    {
        public TaskQueueClient(IConfiguration Configuration) : base(Configuration, WebAPI.TaskQueue) { }


        public string AddJobToEnqueue(int CodeTask, DateTime AimDate, IEnumerable<int> objId)
        {
            throw new NotImplementedException();
        }

        public string AddOrUpdateJob(string CronExpression, int CodeTask, string JobId = "", string queue = "default")
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, string> GetAllCodeTasks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HfJobDTO> GetAllJob()
        {
            throw new NotImplementedException();
        }

        public HfJobDTO GetJobByJobId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HfJobDTO> GetJobsByCodeTasks(HfJobFilterDTO hfJobFilterDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HfJobDTO> GetJobsByDates(HfJobFilterDTO hfJobFilterDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<HfJobDTO> GetJobsByPeriodJobIds(HfJobFilterDTO hfJobFilterDTO)
        {
            throw new NotImplementedException();
        }

        public bool RemoveJob(string JobId)
        {
            throw new NotImplementedException();
        }
    }
}
