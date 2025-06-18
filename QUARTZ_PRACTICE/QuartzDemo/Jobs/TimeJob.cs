// Jobs/TimeJob.cs
using Quartz;
using System;
using System.Threading.Tasks;

namespace QuartzDemo.Jobs
{
    public class TimeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"[TimeJob] Hora actual: {DateTime.Now:HH:mm:ss}");
            return Task.CompletedTask;
        }
    }
}
