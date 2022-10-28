using Serilog.Formatting.Compact;
using Serilog;
using Quartz;
using Quartz.Impl;
using BackGroundProcess.Concole.Jobs;
using Microsoft.Net.Http.Headers;

internal class Program
{
    private static async Task Main(string[] args)
    {
        //.ReadFrom.Configuration(builder.Configuration)
        var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File(new RenderedCompactJsonFormatter(), "../logs/log.json", rollingInterval: RollingInterval.Day)
        .CreateLogger();

        Log.Logger = logger;
        

        StdSchedulerFactory factory = new StdSchedulerFactory();
        IScheduler scheduler = await factory.GetScheduler();


        await scheduler.Start();


        IJobDetail job = JobBuilder.Create<UpdateDataBase>()
         .WithIdentity("job1", "group1")
         .Build();

        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10))
            .Build();

        await scheduler.ScheduleJob(job, trigger);

        await Task.Delay(TimeSpan.FromSeconds(60));


        await scheduler.Shutdown();

        Console.WriteLine("Press any key to close the application");
        Console.ReadKey();
    }
}