using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TaskQueueCore.Domain.DTO.TaskQueue;

namespace TaskQueueCore.Services.Loader
{
    public class LoaderService
    {
        Action<LoaderService> _Method;

        public static Action<LoaderService> GetMethodCall(int CodeTask, DateTime AimDate, IEnumerable<int> ObjId)
        {
            throw new Exception();
        }

    }
}
