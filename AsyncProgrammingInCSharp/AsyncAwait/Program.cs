public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} has started");

        CallPrintHelloWithDelay();
        
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} has finished");

        Task.Delay(6_000).Wait();
    }

    public static async Task CallPrintHelloWithDelay()
    {
        await PrintHelloWithDelay(5_000);
    }

    public static Task PrintHelloWithDelay(int delay)
    {
        return Task.Run(() =>
        {
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} has started");
            Thread.Sleep(delay);
            Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} has finished");
        });
    }
}