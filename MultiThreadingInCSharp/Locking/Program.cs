class Program
{
    public static int sum = 0;
    
    public static object _lock = new object();

    static void Main(string[] args)
    {
        Console.WriteLine("Main Method execution started");

        var t1 = new Thread(Addition);
        var t2 = new Thread(Addition);
        var t3 = new Thread(Addition);
        
        t1.Start();
        t2.Start();
        t3.Start();

        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine($"Result: {sum}");
        
        Console.ReadLine();
    }
    
    public static void Addition()
    {
        for (int i = 1; i < 50_000; i++)
        {
            //sum++;
            //Interlocked.Increment(ref sum);
            lock (_lock)
            {
                sum++;
            }
        }
    }
}
