using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueCore.Domain.DTO.TaskQueue
{
    public class EnqueueDTO
    {
        /// <summary>
        /// Код задачи
        /// </summary>
        public int CodeTask { get; set; }

        /// <summary>
        /// Дата, на которую необходимо выполнить задачу
        /// </summary>
        public DateTime AimDate { get; set; }

        /// <summary>
        /// Список идентификаторов объектов для которых необходимо выполнять задачу
        /// </summary>
        public IEnumerable<int> ObjId { get; set; }
    }
}
