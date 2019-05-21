using System;

namespace FtScheduler
{
    /// <summary>
    /// Schedules tasks to be run in regular intervals.
    /// </summary>
    public interface IScheduler
    {
        /// <summary>
        /// Specifies the interval in which a task should be run.
        /// </summary>
        IScheduleInvoker Every(TimeSpan interval);
    }
}
