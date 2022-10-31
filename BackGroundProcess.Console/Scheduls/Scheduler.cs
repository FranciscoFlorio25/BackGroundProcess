using BackGroundProcess.Concole.Jobs;
using Quartz.Impl;
using Quartz;

namespace BackGroundProcess.Console.Scheduls
{
    public static  class Scheduler
    {
        public async static Task SchedulerTask()
        {

            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();


            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<UpdateDataBase>()
             .WithIdentity("job1", "group1")
             .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(10)
                .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            await Task.Delay(TimeSpan.FromSeconds(60));


            await scheduler.Shutdown();
    
        }
    }
}
