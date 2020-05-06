using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueCore.Domain.ViewModels.TestTask
{
    public class TestTaskViewModel
    {
        /// <summary>
        /// Guid - как признак тектового поля 
        /// </summary>
        public string RandomGuid { get; set; }

        /// <summary>
        /// Дата создания записи
        /// </summary>
        public DateTime EventDateTime { get; set; }

        /// <summary>
        /// Переопределение ToString вывод текущих данных
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"RandomGuid:{RandomGuid}\tEventDateTime:{EventDateTime.ToString("R")}";
        }
    }
}
