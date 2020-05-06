using System;
using System.Collections.Generic;
using System.Text;
using TaskQueueCore.Domain.DTO.TaskQueue;
using TaskQueueCore.Interfaces;

namespace TaskQueueCore.Services.TaskQueue
{
    public class TaskQueueService : ITaskQueue
    {
        //private readonly TestTaskWriteToFile testTaskWriteToFile;

        //public TaskQueueApiController([FromServices] TestTaskWriteToFile TestTaskWriteToFile)
        //{
        //    testTaskWriteToFile = TestTaskWriteToFile;
        //}

        //[HttpGet]
        //public IEnumerable<HfJobDTO> GetAllTask()
        //{
        //    try
        //    {
        //        var succeededJobs = JobStorage
        //        .Current
        //        .GetMonitoringApi()?
        //        .SucceededJobs(0, int.MaxValue)?
        //        .Select(x => new HfJobDTO
        //        {
        //            JobId = x.Key,
        //            Arguments = x.Value?.Job?.Args.ToArray(),
        //            Method = x.Value?.Job?.Method.ToString(),
        //            Result = x.Value?.Result,
        //            RunJob = x.Value?.SucceededAt
        //        }).AsEnumerable();

        //        if (succeededJobs.Count() > 0)
        //            return succeededJobs;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine(ex.ToString());
        //        throw;
        //    }

        //    return new HfJobDTO[0].AsEnumerable();
        //}

        //[HttpGet("{id}")]
        //public string AddJob(int? id)
        //{
        //    var jobId = BackgroundJob.Enqueue(
        //                 () => testTaskWriteToFile.StartTask(id ?? 0));

        //    return jobId;
        //}

        //[HttpGet("{id}/{name}")]
        //public string AddJob2(int? id, string name)
        //{
        //    var jobId = BackgroundJob.Enqueue(
        //                 () => testTaskWriteToFile.StartTask(id ?? 0));

        //    RecurringJob.AddOrUpdate(
        //            () => System.Diagnostics.Debug.WriteLine("Recurring!"), //Console.WriteLine("Recurring!"),
        //            Cron.Daily);

        //    return jobId;
        //}

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
