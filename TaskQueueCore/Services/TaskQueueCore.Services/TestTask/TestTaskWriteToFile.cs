using System;
using System.IO;
using System.Threading;
using TaskQueueCore.Domain.ViewModels.TestTask;

namespace TaskQueueCore.Services.TestTask
{
    public class TestTaskWriteToFile
    {
        public void StartTask(int id = 0)
        {
            using (StreamWriter sw = new StreamWriter("my.txt", true))
            {
                Thread.Sleep(15000);

                TestTaskViewModel testTaskViewModel = new TestTaskViewModel
                {
                    EventDateTime = DateTime.Now,
                    RandomGuid = Guid.NewGuid().ToString()
                };

                sw.WriteLine($"id:{id:####}\t{testTaskViewModel}");
            }
        }
    }
}
