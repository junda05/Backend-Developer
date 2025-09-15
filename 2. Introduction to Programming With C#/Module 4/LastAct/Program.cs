public class Program
{
    public static async Task PerformLongOperationAsync()
    {
        try
        {
            Console.WriteLine("Operation started...");
            await Task.Delay(3000); // Simulate a delay
            throw new InvalidOperationException("Simulated long operation error.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public static void Main(string[] args)
    {
        // Calling the asynchronous method
        Task.Run(async () => await PerformLongOperationAsync()).Wait();
        Console.WriteLine("Main method completed.");
    }
}