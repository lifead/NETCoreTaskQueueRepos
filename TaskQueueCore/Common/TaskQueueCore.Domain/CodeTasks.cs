using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueCore.Domain
{
    public class CodeTasks
    {
        public int CodeTask { get; set; }

        public string ShortName { get; set; }

        public string Description { get; set; }

        public static List<CodeTasks> GetAllCodeTasks => new List<CodeTasks>
        {
            new CodeTasks{ CodeTask =  0 , ShortName = "Test", Description = "Тестовая задача"}
        };
    }
}
