public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} started");
        var task1 = Task<Student>.Run(() =>
        {
            var student = new Student()
            {
                Id = 1, Name = "DotNetOffice"
            };
            return student;
        });
        task1.Wait();

        var student = task1.Result;

        Console.WriteLine($"Sum is: {task1.Result}");
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId} completed");
        Console.ReadKey();
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"Id: {this.Id}, Name: {this.Name}";
    }
}