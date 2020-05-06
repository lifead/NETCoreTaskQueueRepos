using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueCore.Domain.DTO.TaskQueue
{
    public class HfJobFilterDTO
    {
        /// <summary>
        /// Список кодов задач
        /// </summary>
        public IEnumerable<int> CodeTasks { get; set; }

        /// <summary>
        /// Начальный Id задач в базе данных HangFire (по умолчанию 0)
        /// </summary>
        public int StartNumJobSearch { get; set; }

        /// <summary>
        /// Конечный Id задач в базе данных HangFire (по умолчанию int.Max)
        /// </summary>
        public int EndNumJobSearch { get; set; }

        /// <summary>
        /// Дата начала периода выполнения задачи
        /// </summary>
        public DateTime StartDateTimeJobSearch { get; set; }

        /// <summary>
        /// Дата окончания периода выполнения задачи
        /// </summary>
        public DateTime EndDateTimeJobSearch { get; set; }
    }
}
