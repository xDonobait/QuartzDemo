// Program.cs
using Quartz;
using Quartz.Impl;
using QuartzDemo.Jobs;

class Program
{
    static async Task Main(string[] args)
    {
        // Crear el scheduler
        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler scheduler = await factory.GetScheduler();

        await scheduler.Start();

        // Definir el job
        IJobDetail job = JobBuilder.Create<TimeJob>()
            .WithIdentity("timeJob", "group1")
            .Build();

        // Crear el trigger (cada 10 segundos)
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("timeTrigger", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(10)
                .RepeatForever())
            .Build();

        // Asignar el job al trigger
        await scheduler.ScheduleJob(job, trigger);

        // Evitar que se cierre la consola
        Console.WriteLine("Presiona cualquier tecla para terminar...");
        Console.ReadKey();

        await scheduler.Shutdown();
    }
}
