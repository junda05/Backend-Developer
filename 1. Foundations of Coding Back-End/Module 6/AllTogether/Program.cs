// dotnet new console -n name

using System;

public class TaskManager
{
    public static string task1 = "";
    public static string task2 = "";
    public static string task3 = "";

    public static bool task1Completed = false;
    public static bool task2Completed = false;
    public static bool task3Completed = false;

    public static void Main()
    {
        string option;

        do
        {
            Console.WriteLine("Choose option - (1)=Add Task, (2)=Mark Complete, (3)=Display Tasks, (4)=Quit: ");
            option = Console.ReadLine() ?? "";

            switch (option)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    MarkTaskAsCompleted();
                    break;
                case "3":
                    DisplayStatusTasks();
                    break;
                default:
                    Console.WriteLine("Invalid option, try again");
                    break;
            }
        } while (option != "4");
    }

    public static void AddTask()
    {
        Console.WriteLine("Enter a task to store: ");
        string newTask = Console.ReadLine() ?? "";

        if (task1 == "") { task1 = newTask; }
        else if (task2 == "") { task2 = newTask; }
        else if (task3 == "") { task3 = newTask; }
        else { Console.WriteLine("Al three tasks are full"); }
    }

    public static void MarkTaskAsCompleted()
    {
        Console.WriteLine("Select one task to mark as completed (1, 2, 3)");
        int taskToMarkCompleted = int.Parse(Console.ReadLine() ?? "");

        if (taskToMarkCompleted == 1 && task1 != "")
        {
            task1Completed = true;
            Console.WriteLine("Task 1 marked as completed");
        }
        else if (taskToMarkCompleted == 2 && task2 != "")
        {
            task2Completed = true;
            Console.WriteLine("Task 2 marked as completed");
        }
        else if (taskToMarkCompleted == 3 && task3 != "")
        {
            task3Completed = true;
            Console.WriteLine("Task 3 marked as completed");
        }
        else
        {
            Console.WriteLine("Invalid task selection.");
        }
    }

    public static void DisplayStatusTasks()
    {
        if (task1Completed)
        {
            Console.WriteLine($"Task 1 is {task1}.");
            Console.WriteLine($"Its status is: [completed].");
        }
        else
        {
            Console.WriteLine($"Task 1 is {task1}.");
            Console.WriteLine($"Its status is: [incompleted].");
        }

        if (task2Completed)
        {
            Console.WriteLine($"Task 2 is {task2}.");
            Console.WriteLine($"Its status is: [completed].");
        }
        else
        {
            Console.WriteLine($"Task 2 is {task2}.");
            Console.WriteLine($"Its status is: [incompleted].");
        }

        if (task3Completed)
        {
            Console.WriteLine($"Task 3 is {task3}.");
            Console.WriteLine($"Its status is: [completed].");
        }
        else
        {
            Console.WriteLine($"Task 3 is {task3}.");
            Console.WriteLine($"Its status is: [incompleted].");
        }
    }
    
}