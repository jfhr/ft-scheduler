using System;

namespace FtScheduler
{
    public class Scheduler : IScheduler
    {
        public IScheduleInvoker Every(TimeSpan interval)
        {
            return new ScheduleInvoker(interval);
        }
    }
}
