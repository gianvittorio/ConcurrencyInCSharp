public static class Program
{
    public static AutoResetEvent autoResetEvent = new AutoResetEvent(true);

    public static void Main(string[] args)
    {
        var t1 = new Thread(Write);
        t1.Start();

        for (int i = 0; i < 5; i++)
        {
            new Thread(Write).Start();
        }
        
        //Thread.Sleep(4_000);
        //autoResetEvent.Set();
        
        Console.ReadLine();
    }

    public static void Write()
    {
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Waiting");
        autoResetEvent.WaitOne();
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Working");
        Thread.Sleep(5_000);
        
        Console.WriteLine($"Write Thread {Thread.CurrentThread.ManagedThreadId} Completed");
        autoResetEvent.Set();
    }
}