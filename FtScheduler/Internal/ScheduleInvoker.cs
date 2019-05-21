using System;
using System.Timers;

namespace FtScheduler
{
    public class ScheduleInvoker : IScheduleInvoker
    {
        private TimeSpan interval;

        public ScheduleInvoker(TimeSpan interval)
        {
            this.interval = interval;
        }

        public Timer Do(Action action)
        {
            return Do((sender, args) => action());
        }

        public Timer Do(Action<object, ElapsedEventArgs> action)
        {
            var timer = new Timer(interval.TotalMilliseconds);
            timer.Elapsed += new ElapsedEventHandler(action);
            return timer;
        }
    }
}