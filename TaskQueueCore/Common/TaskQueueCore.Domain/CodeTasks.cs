using System;
using System.Collections.Generic;
using System.Text;

namespace TaskQueueCore.Domain
{
    public struct CodeTasks
    {
        public int CodeTask;

        public string ShortName;

        public string Description;

        public static Dictionary<int, string> GetCodeTasks()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();

            dic.Add(0, "Тестовая задача");

            return dic;
        }
    }
}
