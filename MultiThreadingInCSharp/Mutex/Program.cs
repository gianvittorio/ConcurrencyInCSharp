public static class Program
{
    public static Mutex mutex = new Mutex(true);

    public static void Main(string[] args)
    {
        var t1 = new Thread(Write);
        t1.Start();

        for (int i = 0; i < 5; i++)
        {
            new Thread(Write).Start();
        }
        
        //Thread.Sleep(4_000);
        //mutex.ReleaseMutex();
        
        Console.ReadLine();
    }

    public static void Write()
    {
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Waiting");
        mutex.WaitOne();
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Working");
        Thread.Sleep(5_000);
        
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Completed");
        mutex.ReleaseMutex();
    }
}
