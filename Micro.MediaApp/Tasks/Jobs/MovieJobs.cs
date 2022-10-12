using Micro.MediaApp.Tasks.Triggers;
using Quartz;

namespace Micro.MediaApp.Tasks.Jobs
{
    public class MovieJobs:IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            MediaTrigger.GetMoviesFromMainApi();
            return Task.CompletedTask;
        }
    }
}
