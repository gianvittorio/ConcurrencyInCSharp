public static class Program
{
    public static ManualResetEvent manualResetEvent = new ManualResetEvent(false);

    public static void Main(string[] args)
    {
        var t1 = new Thread(Write);
        t1.Start();

        for (int i = 0; i < 5; i++)
        {
            new Thread(Read).Start();
        }

        Console.ReadLine();
    }

    public static void Write()
    {
        Console.WriteLine("Write Thread Working");
        manualResetEvent.Reset();
        Thread.Sleep(5_000);
        
        Console.WriteLine("Write Thread Completed");
        manualResetEvent.Set();
    }

    public static void Read()
    {
        Console.WriteLine("Read Thread Waiting");
        manualResetEvent.WaitOne();
        
        Console.WriteLine("Read Thread Completed");
    }
}