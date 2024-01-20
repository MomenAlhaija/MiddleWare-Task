using System.Diagnostics;

Console.WriteLine("Process ID:\t"+Process.GetCurrentProcess().Id);
Console.WriteLine("Thread ID:\t" + Thread.CurrentThread.ManagedThreadId);
Console.WriteLine("Processor ID:\t" + Thread.GetCurrentProcessorId());