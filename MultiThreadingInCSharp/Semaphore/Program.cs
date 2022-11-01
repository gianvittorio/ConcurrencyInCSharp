public static class Program
{
    public static Semaphore semaphore = new Semaphore(2, 2);

    public static void Main(string[] args)
    {
        var t1 = new Thread(Write);
        t1.Start();

        for (int i = 0; i < 5; i++)
        {
            new Thread(Write).Start();
        }
        
        Console.ReadLine();
    }

    public static void Write()
    {
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Waiting");
        semaphore.WaitOne();
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Working");
        Thread.Sleep(5_000);
        
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Completed");
        semaphore.Release();
    }
}
