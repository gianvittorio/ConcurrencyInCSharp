namespace DeadLock;

public class ATMSystem
{
    private ATMDetails _fromAtm;
    private ATMDetails _toAtm;
    private double _amountToTransfer;

    public ATMSystem(ATMDetails fromAtm, ATMDetails toAtm, double amountToTransfer)
    {
        _fromAtm = fromAtm;
        _toAtm = toAtm;
        _amountToTransfer = amountToTransfer;
    }

    public void Transfer()
    {
        Console.WriteLine($"{Thread.CurrentThread.Name} thread trying to access locking from {_fromAtm.Id.ToString()}");
        lock (_fromAtm)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {_fromAtm.Id}");
            Console.WriteLine($"{Thread.CurrentThread.Name} doing some work");


            Console.WriteLine(
                $"{Thread.CurrentThread.Name} thread trying to sleep for 1 min from {_fromAtm.Id.ToString()}");
            Thread.Sleep(3_000);
            Console.WriteLine(
                $"{Thread.CurrentThread.Name} thread awake from sleep and trying access to lock on {_toAtm.Id.ToString()}");

            if (Monitor.TryEnter(_toAtm, 3_000))
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} acquired lock on {_toAtm.Id}");
                try
                {
                    Console.WriteLine("Logic is working...");
                    _fromAtm.WithDraw(_amountToTransfer);
                    _toAtm.Deposit(_amountToTransfer);
                }
                finally
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} is exiting");
                    Monitor.Exit(_toAtm);
                }
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} Unable to acquire lock on {_toAtm.Id}, thus exiting");
            }
        }
    }
}