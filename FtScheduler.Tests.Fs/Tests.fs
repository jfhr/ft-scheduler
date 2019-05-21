namespace FtScheduler.Tests.Fs

open Microsoft.VisualStudio.TestTools.UnitTesting
open System
open System.Threading
open FtScheduler

[<TestClass>]
type TestClass () =
    let mutable target: IScheduler = null

    [<TestInitialize>]
    member public this.Initialize () =
        target <- new Scheduler()
        ()

    [<TestMethod>] [<Timeout(200)>]
    member public this.ScheduleTask () =
        let mrse = new ManualResetEvent(false)
        
        target.Every(TimeSpan.FromMilliseconds(100.0))
            .Do(fun () -> mrse.Set() |> ignore)
            .Start()

        mrse.WaitOne() |> ignore
        
    [<TestMethod>] [<Timeout(200)>]
    member public this.ScheduleTaskWithEventHandler () =
        let mrse = new ManualResetEvent(false)
                
        target.Every(TimeSpan.FromMilliseconds(100.0))
            .Do(fun sender args -> mrse.Set() |> ignore)
            .Start()
        
        mrse.WaitOne() |> ignore
                
    [<TestMethod>] [<Timeout(200)>]
    member public this.ScheduleMultipleTasks () =
        let mrse1 = new ManualResetEvent(false)
        let mrse2 = new ManualResetEvent(false)
                        
        target.Every(TimeSpan.FromMilliseconds(100.0))
            .Do(fun () -> mrse1.Set() |> ignore)
            .Start()
                
        target.Every(TimeSpan.FromMilliseconds(100.0))
            .Do(fun sender args -> mrse2.Set() |> ignore)
            .Start()

        mrse1.WaitOne() |> ignore
        mrse2.WaitOne() |> ignore

