using Quartz;
using Real_Time_Charts_SignalR.Models.Jobs;

namespace Real_Time_Charts_SignalR.Models
{
    public static class AddJobs
    {
        public static IServiceCollection AddJob(this IServiceCollection services)
        {
            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();

                var jobKey = JobKey.Create(nameof(QueryAlphaVintageJob));

                options.AddJob<QueryAlphaVintageJob>(jobKey)
                .AddTrigger(trigger =>
                trigger.ForJob(jobKey).StartNow().WithSimpleSchedule( s => s.WithIntervalInSeconds(15).RepeatForever()));
            });
            services.AddQuartzHostedService(options =>
            {
                options.WaitForJobsToComplete = true;
            });
            return services;
        }
    }
}
