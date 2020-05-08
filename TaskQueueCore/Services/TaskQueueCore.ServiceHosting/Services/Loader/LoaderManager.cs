using Hangfire;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TaskQueueCore.Domain;
using TaskQueueCore.Domain.DTO.TaskQueue;

namespace TaskQueueCore.ServiceHosting.Services.Loader
{
    public class LoaderManager
    {
        #region Добавление задач, которые необходимо выполнить "сейчас"
        /// <summary>
        /// Добавление задач, которые необходимо выполнить "сейчас"
        /// </summary>
        /// <param name="enqueueDTO"></param>
        /// <returns></returns>
        public string AddEnqueue(EnqueueDTO enqueueDTO)
        {
            //Проверка, существует ли такая задача
            if (!CodeTasks.GetAllCodeTasks.Any(x => x.CodeTask == enqueueDTO.CodeTask))
                return "-1";

            string jobId = string.Empty;

            switch (enqueueDTO.CodeTask)
            {
                case 0:
                    jobId = BackgroundJob.Enqueue<LoaderManager>(x => RunTestJob(enqueueDTO.AimDate, enqueueDTO.ObjId));
                    break;
                default:
                    jobId = "-1";
                    break;
            }

            return jobId;
        } 
        #endregion

        #region Добавление/обновление задач в расписание
        /// <summary>
        /// Добавление/обновление задач в расписание
        /// </summary>
        /// <param name="recurringDTO"></param>
        public void AddRecurring(RecurringDTO recurringDTO)
        {
            RecurringJob.AddOrUpdate<LoaderManager>(recurringDTO.JobId,
                    x => RunTestJob(DateTime.Now, new int[] { 11, 12 }),
                    recurringDTO.CronExpression,
                    null,
                    recurringDTO.Queue);
        } 
        #endregion

        #region Тестовая задача, для тестирования работоспособности запуска задач
        /// <summary>
        /// Тестовая задача, для тестирования работоспособности запуска задач
        /// </summary>
        /// <param name="AimDate">Дата, на которую необходимо выполнить задачу</param>
        /// <param name="ObjId">список объектов для которых необходимо выполнить задачу</param>
        public static void RunTestJob(DateTime AimDate, IEnumerable<int> ObjIds)
        {
            Debug.WriteLine($"Тестовая задача: AimDate: {AimDate}\t ObjId: {string.Join(", ", ObjIds)}");
        } 
        #endregion
    }
}
