class TaskManager()
{
    static List<string> tasks = new List<string>();
    static List<bool> tasksStatus = new List<bool>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Task Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Marks Task as Completed");
            Console.WriteLine("3. View Tasks");
            Console.WriteLine("4. Exit");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    CompleteTask();
                    break;
                case "3":
                    ViewTasks();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, try again");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.WriteLine("Enter task description: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        tasksStatus.Add(false);
        Console.WriteLine("Task Added Successfully");
    }

    static void TaskAvailable()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks available to complete");
            return;
        }
    }
    
    static void CompleteTask()
    {
        TaskAvailable();    
        Console.WriteLine("Enter a task number to mark as completed: ");

        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber > 0 && taskNumber <= tasks.Count)
        {
            tasksStatus[taskNumber - 1] = true;
            Console.WriteLine($"Task '{tasks[taskNumber - 1]}' marked as completed");
        }
        else { Console.WriteLine("Invalid task number"); }
    }

    static void ViewTasks()
    {
        TaskAvailable();
        Console.WriteLine("Enter a task number to mask as completed: ");

        Console.WriteLine("Tasks: ");
        for (int i = 0; i < tasks.Count; i++)
        {
            string status = tasksStatus[i] ? "Completed" : "Pending";
            Console.WriteLine($"{i + 1}. {tasks[i]} - {status}");
        }   
    }
    
}