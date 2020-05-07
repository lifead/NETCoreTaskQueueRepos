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


        public string AddJobToEnqueue(EnqueueDTO enqueueDTO)
        {
            throw new NotImplementedException();
        }

        public string AddOrUpdateJob(RecurringDTO recurringDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CodeTasks> GetAllCodeTasks()
        {
            return Get<List<CodeTasks>>($"{_ServiceAddress}");
        }

        public IEnumerable<HfJobDTO> GetAllJob()
        {
            return Get<List<HfJobDTO>>($"{_ServiceAddress}/{nameof(GetAllJob)}");
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
