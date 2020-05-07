﻿using Microsoft.AspNetCore.Mvc;
using System;
using TaskQueueCore.Domain;
using TaskQueueCore.Domain.DTO.TaskQueue;
using TaskQueueCore.Interfaces;
using TaskQueueCore.Services.TestTask;

namespace TaskQueueCore.ServiceHosting.Controllers
{
    [Route(WebAPI.TestTask)]
    [ApiController]
    public class TestTaskApiController : ControllerBase
    {
        private readonly TestTaskWriteToFile testTaskWriteToFile;
        private readonly ITaskQueue _TaskQueue;

        public TestTaskApiController([FromServices] TestTaskWriteToFile TestTaskWriteToFile, ITaskQueue TaskQueue)
        {
            testTaskWriteToFile = TestTaskWriteToFile;
            _TaskQueue = TaskQueue;
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

        [HttpGet("AddEnqueue")]
        public string AddEnqueue()
        {
            string jobId = _TaskQueue.AddJobToEnqueue(new EnqueueDTO
            {
                CodeTask = 0,
                AimDate = DateTime.Now,
                ObjId = new int[] { 5, 7, 9 }
            });
            return jobId;
        }

    }
}