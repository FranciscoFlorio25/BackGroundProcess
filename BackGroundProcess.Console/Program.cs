using Serilog.Formatting.Compact;
using Serilog;
using Quartz;
using Quartz.Impl;
using BackGroundProcess.Concole.Jobs;
using Microsoft.Net.Http.Headers;
using BackGroundProcess.Console.Scheduls;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var logger = new LoggerConfiguration()
        .WriteTo.Console()
        .WriteTo.File(new RenderedCompactJsonFormatter(), "../logs/log.json", rollingInterval: RollingInterval.Day)
        .CreateLogger();

        Log.Logger = logger;

        await Scheduler.SchedulerTask();
    }
}