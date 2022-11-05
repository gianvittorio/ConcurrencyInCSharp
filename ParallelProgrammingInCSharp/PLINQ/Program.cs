public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Started");

        var source = Enumerable.Range(100, 500);

        var evenNums = from num in source.AsParallel().WithDegreeOfParallelism(2)
            where num % 2 == 0
            select num;
        Console.WriteLine("{0} even numbers out of {1} total", evenNums.Count(), source.Count());

        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} Completed");

        Console.ReadLine();
    }
}