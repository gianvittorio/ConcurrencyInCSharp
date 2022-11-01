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
        var random = await GetRandomAsync(5_000);
        Console.WriteLine($"Random Number: {random}");
    }

    public static Task<int> GetRandomAsync(int delay)
    {
        return Task.Run(() =>
        {
            try
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} has started");
                var random = new Random().Next();
                Thread.Sleep(delay);
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} has finished");
                throw new Exception("Oops");

                return random;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e}");
                return -1;
            }
        });
    }
}