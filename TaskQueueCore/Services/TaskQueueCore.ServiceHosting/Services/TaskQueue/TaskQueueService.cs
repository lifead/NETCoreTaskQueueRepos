using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskQueueCore.Domain;
using TaskQueueCore.Domain.DTO.TaskQueue;
using TaskQueueCore.Interfaces;

namespace TaskQueueCore.ServiceHosting.Services.TaskQueue
{
    public class TaskQueueService : ITaskQueue
    {
        #region пример работы с Hangfire
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
        #endregion

        public string AddJobToEnqueue(EnqueueDTO enqueueDTO)
        {
            try
            {
                //var method = LoaderService.GetMethodCall(0, enqueueDTO.AimDate, enqueueDTO.ObjId);
                //method(DateTime.Now, new int[] { 6, 3 });

                //var jobId = BackgroundJob.Enqueue<LoaderService>(x => method(DateTime.Now, new int[] { 7, 9 }));
                ////var jobId = BackgroundJob.Enqueue(() => System.Diagnostics.Debug.WriteLine(55155));
                //return jobId;
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return "error";

                throw;
            }
        }

        public string AddOrUpdateJob(RecurringDTO recurringDTO)
        {
            //RecurringJob.AddOrUpdate(recurringDTO.JobId,
            //        () => LoaderService.GetMethodCall(recurringDTO.CodeTask, DateTime.Now, null),
            //        recurringDTO.CronExpression,
            //        null,
            //        recurringDTO.Queue);

            throw new NotImplementedException();
        }

        public IEnumerable<CodeTasks> GetAllCodeTasks()
        {
            throw new NotImplementedException();
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

        public IEnumerable<HfJobDTO> GetJobsByPeriodJobIds(HfJobFilterDTO hfJobFilterDTO)
        {
            try
            {
                var succeededJobs = JobStorage
                .Current
                .GetMonitoringApi()?
                .ScheduledJobs(hfJobFilterDTO.StartNumJobSearch, hfJobFilterDTO.EndNumJobSearch)?
                //.SucceededJobs(0, int.MaxValue)?
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

        public bool RemoveJob(string JobId)
        {
            try
            {
                RecurringJob.RemoveIfExists(JobId);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<HfJobDTO> GetJobsByCodeTasks(HfJobFilterDTO hfJobFilterDTO)
        {
            //ToDo  - сделана заглушка, для проведения тестирования работы
            return new HfJobDTO[0].AsEnumerable();

            //throw new NotImplementedException();
        }

        public IEnumerable<HfJobDTO> GetJobsByDates(HfJobFilterDTO hfJobFilterDTO)
        {
            //ToDo  - сделана заглушка, для проведения тестирования работы

            return new HfJobDTO[0].AsEnumerable();
            //throw new NotImplementedException();
        }
    }
}
