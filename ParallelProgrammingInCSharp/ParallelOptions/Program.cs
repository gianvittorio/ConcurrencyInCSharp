public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");

        int length = 300;
        int data = 0;
        Console.WriteLine("C# parallel \"for\" loop");

        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 2
        };

        Parallel.For(0, length, parallelOptions,
            (count, breakCount) =>
            {
                data += count;
                if (data > 100)
                {
                    breakCount.Stop();
                    Console.WriteLine($"The value is {count} and data: {data}");
                }
            });

        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");

        Console.ReadLine();
    }
}