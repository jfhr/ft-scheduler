Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Threading

Namespace FtScheduler.Tests.Vb
    <TestClass>
    Public Class Tests
        Private target As IScheduler

        <TestInitialize>
        Public Sub Initialize()
            target = New Scheduler()
        End Sub

        <TestMethod> <Timeout(200)>
        Public Sub ScheduleTask()
            Dim mrse As ManualResetEvent = New ManualResetEvent(False)
            target.Every(TimeSpan.FromMilliseconds(100.0)).
                Do(New Action(AddressOf mrse.Set)).
                Start()

            mrse.WaitOne()
        End Sub

        <TestMethod> <Timeout(200)>
        Public Sub ScheduleTaskWithEventHandler()
            Dim mrse As ManualResetEvent = New ManualResetEvent(False)
            target.Every(TimeSpan.FromMilliseconds(100.0)).
                Do(Function(sender, args) mrse.Set()).
                Start()

            mrse.WaitOne()
        End Sub

        <TestMethod> <Timeout(300)>
        Public Sub ScheduleMultipleTasks()
            Dim mrse1 As ManualResetEvent = New ManualResetEvent(False)
            Dim mrse2 As ManualResetEvent = New ManualResetEvent(False)

            target.Every(TimeSpan.FromMilliseconds(100.0)).
                Do(New Action(AddressOf mrse1.Set)).
                Start()
            target.Every(TimeSpan.FromMilliseconds(100.0)).
                Do(Function(sender, args) mrse2.Set()).
                Start()

            mrse1.WaitOne()
            mrse2.WaitOne()
        End Sub
    End Class
End Namespace

