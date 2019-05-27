# Ft-scheduler

This package provides a simple, fluent interface around the builtin
[`System.Timers.Timer`](https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer?view=netstandard-2.0)
class to declare recurring tasks.

## Examples

### C#
```csharp
var scheduler = new Scheduler();
scheduler.Every(TimeSpan.FromHours(24))
    .Do((sender, args) => Console.WriteLine($"Current Time: {args.SignalTime}"))
    .Start();
```

### F#
```fsharp
let scheduler = new Scheduler()
scheduler.Every(TimeSpan.FromMilliseconds(100.0))
    .Do(fun () -> Console.WriteLine("100 milliseconds passed"))
    .Start()
```

### VB.NET
```vbnet
Dim skewedTime As Integer = Date.Now.Ticks
Dim scheduler As Scheduler = New Scheduler()
scheduler.Every(TimeSpan.FromSeconds(5)).
    Do(Function(sender, args) skewedTime = args.SignalTime.Ticks).
    Start()
```
