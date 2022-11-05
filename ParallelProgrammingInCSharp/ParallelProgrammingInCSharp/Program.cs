using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");

        int length = 10;
        Console.WriteLine("C# standard \"for\" loop");

        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine($"The value is {i} and the thread is {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(10);
        }

        stopwatch.Stop();
        Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");

        stopwatch = Stopwatch.StartNew();
        Console.WriteLine("C# parallel \"for\" loop");
        Parallel.For(0, length,
            count =>
            {
                Console.WriteLine($"The value is {count} and the thread is {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });
        stopwatch.Stop();
        Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds}ms");

        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");

        Console.ReadLine();
    }
}