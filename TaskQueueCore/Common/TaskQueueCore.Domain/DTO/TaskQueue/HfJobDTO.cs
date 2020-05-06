using System;

namespace TaskQueueCore.Domain.DTO.TaskQueue
{
    public class HfJobDTO
    {
        /// <summary>
        /// Код задачи
        /// </summary>
        public int CodeTask { get; set; }

        /// <summary>
        /// Id задачи в очереди HangFire
        /// </summary>
        public string JobId { get; set; }

        /// <summary>
        /// Дата запуска задачи
        /// </summary>
        public DateTime? RunJob { get; set; }

        /// <summary>
        /// Перечень аргументов
        /// </summary>
        public object[] Arguments { get; set; }

        /// <summary>
        /// Результат выполнения
        /// </summary>
        public object Result { get; set; }

        /// <summary>
        /// Название метода, который был вызван
        /// </summary>
        public string Method { get; set; }
    }
}
