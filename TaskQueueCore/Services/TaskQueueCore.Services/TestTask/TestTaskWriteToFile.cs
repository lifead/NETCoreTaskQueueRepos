using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TaskQueueCore.Domain.ViewModels.TestTask;

namespace TaskQueueCore.Services.TestTask
{
    public class TestTaskWriteToFile
    {
        public void StartTask()
        {
            using (StreamWriter sw = new StreamWriter("my.txt", true))
            {
                TestTaskViewModel testTaskViewModel = new TestTaskViewModel {
                    EventDateTime = DateTime.Now,
                    RandomGuid = Guid.NewGuid().ToString()
                };
                sw.WriteLine(testTaskViewModel.ToString());
            }
        }
    }
}
