using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskQueueCore.Clients.Base;
using TaskQueueCore.Domain;
using TaskQueueCore.Domain.DTO.TaskQueue;
using TaskQueueCore.Interfaces;

namespace TaskQueueCore.Clients.TaskQueue
{
    public class TaskQueueClient : BaseClient, ITaskQueue
    {
        public TaskQueueClient(IConfiguration Configuration) : base(Configuration, WebAPI.TaskQueue) { }

        public async Task<string> AddEnqueueJobAsync(EnqueueDTO EnqueueDTO)
        {
            var response = await PostAsync($"{_ServiceAddress}/{nameof(AddEnqueueJobAsync)}", EnqueueDTO);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> AddRecurringJobAsync(RecurringDTO RecurringDTO)
        {
            var response = await PostAsync($"{_ServiceAddress}/{nameof(AddRecurringJobAsync)}", RecurringDTO);
            return await response.Content.ReadAsStringAsync();
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

        public Task<bool> RemoveJobAsync(string JobId)
        {
            throw new NotImplementedException();
        }
    }
}
