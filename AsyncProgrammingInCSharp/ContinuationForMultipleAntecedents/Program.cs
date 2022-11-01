public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} started");
        var task1 = Task<string>.Run(() => Total(5))
            .ContinueWith(info => { return $"the sum is {info.Result}"; })
            .ContinueWith(antecedent => { return $"the new result is {antecedent.Result}"; });
        
        task1.ContinueWith(details =>
        {
            Console.WriteLine("New continue with method");   
        });

        Task.Delay(1_000).Wait();

        Console.WriteLine($"Sum is: {task1.Result}");
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} completed");
        Console.ReadKey();
    }

    public static int Total(int max)
    {
        int sum = 0;
        Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} started");
        for (int count = 1; count <= max; count++)
        {
            sum += count;
        }

        Console.WriteLine($"Child Thread: {Thread.CurrentThread.ManagedThreadId} completed");
        return sum;
    }
}