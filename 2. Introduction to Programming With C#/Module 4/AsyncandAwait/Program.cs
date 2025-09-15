//  The await keyword suspends the execution of the method until the awaited task completes, allowing other tasks to run in the meantime.
// public class Task {
//     public async Task<string> GetDataAsync() {
//         try {
//             var data = await GetDataFromApi();
//         }
//         catch (Exception ex) {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }

// using System.Threading.Tasks;

// public class Program
// {
//     public async Task DownloadDataAsync()
//     {
//         Console.WriteLine("Downloading");
//         await Task.Delay(5000);
//         Console.WriteLine("Downloaded");
//     }
//     public async Task DownloadDataAsync2()
//     {
//         Console.WriteLine("Downloading");
//         await Task.Delay(5000);
//         Console.WriteLine("Downloaded");
//     }

//     public static async Task Main()
//     {
//         try
//         {
//             // Program program = new Program();
//             // Task task1 = program.DownloadDataAsync();
//             // Task task2 = program.DownloadDataAsync2();
//             // await Task.WhenAll(task1, task2);
//             // Console.WriteLine("All downloads completed.");

//             // Program download1 = new Program();
//             Program download = new Program();

//             // await download1.DownloadDataAsync();
//             // Ejecuta ambas tareas en paralelo
//             await Task.WhenAll(
//                 download.DownloadDataAsync(),
//                 download.DownloadDataAsync2()
//             );
//             Console.WriteLine("Both downloads finished!");

//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }

// Simulating errors

public class Program
{
	
    public async Task DownloadDataAsync()
    {
        try
        {
            Console.WriteLine("Download started...");
            throw new InvalidOperationException("Simulated download error.");
            await Task.Delay(3000);
            Console.WriteLine("Download completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }

    public async Task DownloadDataAsync2()
    {
        Console.WriteLine("Download 2 started...");
        await Task.Delay(2000);
        Console.WriteLine("Download 2 completed.");
    }

    public static async Task Main(string[] args)
    {
        Program program = new Program();
        Task task1 = program.DownloadDataAsync();
        Task task2 = program.DownloadDataAsync2();
        await Task.WhenAll(task1, task2);
        Console.WriteLine("All downloads completed.");
    }
}