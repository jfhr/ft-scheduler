using System;
using System.Timers;

namespace FtScheduler
{
    /// <summary>
    /// Schedules actions to be taken when a task is elapsed.
    /// </summary>
    public interface IScheduleInvoker
    {
        /// <summary>
        /// Specifies an action to be run when this task is elapsed.
        /// </summary>
        Timer Do(Action action);
        /// <summary>
        /// Specifies an action to be run when this task is elapsed.
        /// The action will be passed the unerlying <see cref="Timer"/>'s
        /// event args as parameters.
        /// </summary>
        Timer Do(Action<object, ElapsedEventArgs> action);
    }
}