public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");

        var parallelOptions = new ParallelOptions()
        {
            MaxDegreeOfParallelism = 3
        };
        Parallel.Invoke(parallelOptions, () => PrintNum(1), () => PrintNum(1),
            delegate()
            {
                Console.WriteLine($"Anonymous method. Thread: {Thread.CurrentThread.ManagedThreadId} Started");
            },
            () => { Console.WriteLine($"lambda method. Thread: {Thread.CurrentThread.ManagedThreadId} Started"); });

        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");

        Console.ReadLine();
    }

    public static void PrintNum(int num)
    {
        Console.WriteLine($"The num is {num}. Thread: {Thread.CurrentThread.ManagedThreadId} Started");
        Thread.Sleep(10);
    }
}