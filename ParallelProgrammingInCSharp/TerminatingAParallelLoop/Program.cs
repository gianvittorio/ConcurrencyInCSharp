public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");

        int length = 10;
        Console.WriteLine("C# parallel \"for\" loop");

        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 2
        };

        Parallel.For(0, length, parallelOptions,
            count =>
            {
                Console.WriteLine($"The value is {count} and the thread is {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            });

        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");

        Console.ReadLine();
    }
}