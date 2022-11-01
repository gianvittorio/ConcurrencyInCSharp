public static class Program
{
    public static object _lock = new object();
    
    public static void Main(string[] args)
    {
        var writeThread = new Thread(Write);
        var readThread = new Thread(Read);
        
        writeThread.Start();
        readThread.Start();

        writeThread.Join();
        readThread.Join();
        
        Console.ReadLine();
    }

    public static void Write()
    {
        Monitor.Enter(_lock);
        
        for (int i = 0; i < 5; i++)
        {
            Monitor.Pulse(_lock);
            Console.WriteLine($"Write Thread Working... {i}");
            
            Console.WriteLine("Write Thread completed");
            Monitor.Wait(_lock);
        }
    }
    
    public static void Read()
    {
        Monitor.Enter(_lock);
        
        for (int i = 0; i < 5; i++)
        {
            Monitor.Pulse(_lock);
            Console.WriteLine($"Read Thread Working... {i}");

            Console.WriteLine("Read Thread completed");
            Monitor.Wait(_lock);
        }
    }
}
