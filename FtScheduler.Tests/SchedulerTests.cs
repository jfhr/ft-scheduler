using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;

namespace FtScheduler.Tests
{
    [TestClass]
    public class SchedulerTests
    {
        private IScheduler target;

        [TestInitialize]
        public void Initialize()
        {
            target = new Scheduler();
        }

        [TestMethod, Timeout(200)] 
        public void ScheduleTask()
        {
            var mrse = new ManualResetEvent(false);

            target.Every(TimeSpan.FromMilliseconds(100))
                .Do(() => mrse.Set())
                .Start();

            mrse.WaitOne(); 
        }

        [TestMethod, Timeout(200)]
        public void ScheduleTaskWithEventHandler()
        {
            var mrse = new ManualResetEvent(false);

            target.Every(TimeSpan.FromMilliseconds(100))
                .Do((sender, args) => mrse.Set())
                .Start();

            mrse.WaitOne();
        }

        [TestMethod, Timeout(300)]
        public void ScheduleMultipleTasks()
        {
            var mrse1 = new ManualResetEvent(false);
            var mrse2 = new ManualResetEvent(false);

            target.Every(TimeSpan.FromMilliseconds(100))
                .Do((sender, args) => mrse1.Set())
                .Start();

            target
                .Every(TimeSpan.FromMilliseconds(100))
                .Do(() => mrse2.Set())
                .Start();

            mrse1.WaitOne();
            mrse2.WaitOne();
        }
    }
}
