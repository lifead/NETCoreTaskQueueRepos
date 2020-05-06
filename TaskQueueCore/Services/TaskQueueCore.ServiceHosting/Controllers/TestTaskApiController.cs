using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskQueueCore.Domain;
using TaskQueueCore.Services.TestTask;

namespace TaskQueueCore.ServiceHosting.Controllers
{
    [Route(WebAPI.TestTask)]
    [ApiController]
    public class TestTaskApiController : ControllerBase
    {
        private readonly TestTaskWriteToFile testTaskWriteToFile;

        public TestTaskApiController([FromServices] TestTaskWriteToFile TestTaskWriteToFile)
        {
            testTaskWriteToFile = TestTaskWriteToFile;
        }

        [HttpGet]
        public string StartTask()
        {
            try
            {
                testTaskWriteToFile.StartTask();
                return true.ToString();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}