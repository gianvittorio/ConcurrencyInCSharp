public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Main method started");
        for (int i = 0; i < 5; i++)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadPoolMethod));
        }
        Console.WriteLine("Main method completed");
        Console.ReadLine();
    }

    public static void ThreadPoolMethod(object obj)
    {
        var currentThread = Thread.CurrentThread;
        string message =
            $"Background: {currentThread.IsBackground}, Thread Pool: {currentThread.IsThreadPoolThread}, Thread ID: {currentThread.ManagedThreadId}";
        Console.WriteLine(message);
    }
}