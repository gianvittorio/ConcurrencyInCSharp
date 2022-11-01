using DeadLock;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Main method started");

        var atmDetails1 = new ATMDetails(501, 5_000);
        var atmDetails2 = new ATMDetails(502, 6_000);

        var atmSystem1 = new ATMSystem(atmDetails1, atmDetails2, 500);
        var t1 = new Thread(atmSystem1.Transfer);
        t1.Name = "T1";
        
        var atmSystem2 = new ATMSystem(atmDetails2, atmDetails1, 500);
        var t2 = new Thread(atmSystem2.Transfer);
        t2.Name = "T2";
        
        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();
        
        Console.WriteLine("Main method completed");
        
        Console.ReadLine();
    }
}
