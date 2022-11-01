using System.Diagnostics;

int max = 10;
var numberHelper = new NumberHelper(max, Console.WriteLine);
ThreadStart obj = new ThreadStart(numberHelper.ShowNumbers);
var t = new Thread(obj);
t.Start();

var stopwatch = new Stopwatch();
stopwatch.Start();

t.Join(5_000);

Console.WriteLine($"Elapsed: {stopwatch.ElapsedMilliseconds}ms");

stopwatch.Stop();
Console.ReadKey();

public delegate void SumOfNumberCallbackDelegate(int sumOfNums);

public class NumberHelper
{
    private int _number;
    private SumOfNumberCallbackDelegate _callbackDelegate;

    public NumberHelper(int number, SumOfNumberCallbackDelegate _delegate)
    {
        _number = number;
        _callbackDelegate = _delegate;
    }

    public void ShowNumbers()
    {
        int sum = 0;
        foreach (var i in Enumerable.Range(0, _number))
        {
            sum += i;
        }

        Thread.Sleep(5_000);
        
        if (_callbackDelegate != null)
        {
            _callbackDelegate(sum);    
        }
    }
}