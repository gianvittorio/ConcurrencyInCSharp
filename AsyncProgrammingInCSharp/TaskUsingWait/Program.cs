public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} started");
        var task1 = Task.Run(PrintCounter);
        task1.Wait();
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} completed");
        Console.ReadKey();
    }

    public static void PrintCounter()
    {
        Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} started");
        for (int count = 1; count <= 5; count++)
        {
            Console.WriteLine($"count value {count}");
        }

        Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} completed");
    }
}