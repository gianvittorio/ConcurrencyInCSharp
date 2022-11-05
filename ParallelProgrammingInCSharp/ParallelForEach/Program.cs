using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");

        var collection = Enumerable.Range(0, 10).ToList();
        Console.WriteLine($"Parallel \"foreach\" loop");

        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 2
        };
        Parallel.ForEach(collection, parallelOptions, i =>
        {
            Console.WriteLine($"The value is {i} and Thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(10);
        });

        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");

        Console.ReadLine();
    }
}