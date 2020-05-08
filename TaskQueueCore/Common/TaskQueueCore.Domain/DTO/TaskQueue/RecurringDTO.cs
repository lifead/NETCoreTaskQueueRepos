using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueCore.Domain.DTO.TaskQueue
{
    public class RecurringDTO
    {
        /// <summary>
        /// Расписание в формате Cron
        /// </summary>
        public string CronExpression { get; set; }

        /// <summary>
        /// Код задачи
        /// </summary>
        public int CodeTask { get; set; }

        /// <summary>
        /// Сокращенное название задачи (заполнять только при добавлении новой задачи)
        /// </summary>
        public string ShortNameJob { get; set; } = string.Empty;

        /// <summary>
        /// JobId - задачи в базе данных Hangfire
        /// </summary>
        public string JobId { get; set; } = "";

        /// <summary>
        /// Название очереди, по умолчанию название: "default"
        /// </summary>
        public string Queue { get; set; } = "default";
    }
}
