using System;
using System.Collections.Generic;
using TaskQueueCore.Domain.DTO.TaskQueue;

namespace TaskQueueCore.Interfaces
{
    public interface ITaskQueue
    {
        /// <summary>
        /// Получить все доступные задачи для запуска в HangFire
        /// </summary>
        /// <returns>
        /// int - код задачи которую надо запустить;
        /// string - краткое описание задачи
        /// </returns>
        Dictionary<int, string> GetAllCodeTasks();

        /// <summary>
        /// Получить все задачи запущенные в HangFire
        /// </summary>
        /// <returns></returns>
        IEnumerable<HfJobDTO> GetAllJob();

        /// <summary>
        /// Получить данные о ходе выполнения задачи по JobId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HfJobDTO GetJobByJobId(int Id);

        /// <summary>
        /// Получить перечень задач по коду задачи
        /// </summary>
        /// <param name="HfJobFilterDTO">
        /// Список кодов задач для заппуска, поле в фильтре HfJobFilterDTO: 
        /// IEnumerable<int> CodeTasks</param>
        /// <returns></returns>
        IEnumerable<HfJobDTO> GetJobsByCodeTasks(HfJobFilterDTO HfJobFilterDTO);

        /// <summary>
        /// Получить перечень задач по зданому диапазону номеров задач
        /// </summary>
        /// <param name="HfJobFilterDTO">
        /// Начальный Id задач в базе данных HangFire (по умолчанию 0), поле в фильтре HfJobFilterDTO:
        /// int StartNumJobSearch; 
        /// Конечный Id задач в базе данных HangFire (по умолчанию int.Max), поле в фильтре HfJobFilterDTO:
        /// int EndNumJobSearch;
        /// </param>
        /// <returns></returns>
        IEnumerable<HfJobDTO> GetJobsByPeriodJobIds(HfJobFilterDTO HfJobFilterDTO);

        /// <summary>
        ///  Получить перечень задач по зданому диапазону дат
        /// </summary>
        /// <param name="HfJobFilterDTO">
        /// Дата начала периода выполнения задачи, поле в фильтре HfJobFilterDTO:
        /// DateTime StartDateTimeJobSearch; 
        /// Дата окончания периода выполнения задачи, поле в фильтре HfJobFilterDTO:
        /// DateTime EndDateTimeJobSearch;
        /// </param>
        /// <returns></returns>
        IEnumerable<HfJobDTO> GetJobsByDates(HfJobFilterDTO HfJobFilterDTO);


        /// <summary>
        /// Добавление задачи на "немедленное" выполнение
        /// </summary>
        /// <param name="CodeTask">Код задачи</param>
        /// <param name="AimDate">Дата, на которую необходимо выполнить задачу</param>
        /// <param name="ObjId">Перечень объектов для которых необходимо выполнить задачу</param>
        /// <returns>Возвращает Id задачи в базе данных HandFire</returns>
        string AddJobToEnqueue(EnqueueDTO EnqueueDTO);


        /// <summary>
        /// Добавление задачи на выполнение по расписанию
        /// </summary>
        /// <param name="CronExpression">расписание в формате Cron</param>
        /// <param name="CodeTask">Код задачи</param>
        /// <param name="JobId">JobId задачи в базе данных HangFire</param>
        /// <param name="Queue">название очереди</param>
        /// <returns></returns>
        string AddOrUpdateJob(RecurringDTO RecurringDTO);


        /// <summary>
        /// Удаление задачи по JobId
        /// </summary>
        /// <param name="JobId"></param>
        /// <returns></returns>
        bool RemoveJob(string JobId);
    }
}
