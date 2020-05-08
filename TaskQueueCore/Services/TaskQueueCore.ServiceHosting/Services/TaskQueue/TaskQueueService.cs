using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskQueueCore.Domain;
using TaskQueueCore.Domain.DTO.TaskQueue;
using TaskQueueCore.Interfaces;

namespace TaskQueueCore.ServiceHosting.Services.TaskQueue
{
    public class TaskQueueService : ITaskQueue
    {
        public async Task<string> AddEnqueueJobAsync(EnqueueDTO EnqueueDTO)
        {
            try
            {
                var loader = new Loader.LoaderManager();
                string jobId = string.Empty;
                await Task.Run(() =>  {
                    jobId = loader.AddEnqueue(EnqueueDTO);
                });
                return jobId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<string> AddRecurringJobAsync(RecurringDTO RecurringDTO)
        {
            try
            {
                var loader = new Loader.LoaderManager();
                await Task.Run(() => {
                    new Loader.LoaderManager().AddRecurring(RecurringDTO);
                });
                return "true";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<CodeTasks> GetAllCodeTasks()
        {
            return CodeTasks.GetAllCodeTasks;
        }

        public IEnumerable<HfJobDTO> GetAllJob()
        {
            try
            {
                var succeededJobs = JobStorage
                .Current
                .GetMonitoringApi()?
                //.ScheduledJobs(0, int.MaxValue)?
                .SucceededJobs(0, int.MaxValue)?
                .Select(x => new HfJobDTO
                {
                    JobId = x.Key,
                    Arguments = x.Value?.Job?.Args.ToArray(),
                    Method = x.Value?.Job?.Method.ToString(),
                        //Result = x.Value?.Result,
                        //RunJob = x.Value?.SucceededAt
                    }).AsEnumerable();

                if (succeededJobs.Count() > 0)
                    return succeededJobs;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }

            return new HfJobDTO[0].AsEnumerable();
        }

        public HfJobDTO GetJobByJobId(int Id)
        {
            try
            {
                var succeededJobs = JobStorage
                .Current
                .GetMonitoringApi()?
                .ScheduledJobs(Id, Id)?
                //.SucceededJobs(0, int.MaxValue)?
                .Select(x => new HfJobDTO
                {
                    JobId = x.Key,
                    Arguments = x.Value?.Job?.Args.ToArray(),
                    Method = x.Value?.Job?.Method.ToString(),
                        //Result = x.Value?.Result,
                        //RunJob = x.Value?.SucceededAt
                    }).FirstOrDefault();

                if (succeededJobs != null)
                    return succeededJobs;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                throw;
            }

            return new HfJobDTO();
        }

        public async Task<bool> RemoveJobAsync(string JobId)
        {
            try
            {
                var loader = new Loader.LoaderManager();
                await Task.Run(() => {
                    RecurringJob.RemoveIfExists(JobId);
                });
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
