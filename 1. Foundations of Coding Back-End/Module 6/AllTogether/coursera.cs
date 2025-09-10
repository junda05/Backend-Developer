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

	//we create a loop that runs until user quits
	Console.WriteLine("Choose option - (1)=Add Task, (2)=Mark Complete, (3)=Display Tasks, (4)=Quit: ");
	string option = Console.ReadLine();
	while (option != "4") {
		if (option == "1")
			EnterTask();
		else if (option == "2")
			MarkCompleted();
		else if (option == "3")
			DisplayTasks();
		
		if (option != "4") {
			Console.WriteLine("Choose option - (1)=Add Task, (2)=Mark Complete, (3)=Display Tasks, (4)=Quit: ");
			option = Console.ReadLine();
		}
	}
    }

    public static void EnterTask() {
        Console.WriteLine("Add your task: ");
        string newTask = Console.ReadLine();

        if (string.IsNullOrEmpty(task1)) 
        {
            task1 = newTask;
        }
        else if (string.IsNullOrEmpty(task2)) 
        {
            task2 = newTask;
        }
        else if (string.IsNullOrEmpty(task3)) 
        {
            task3 = newTask;
        }
        else 
        {
            Console.WriteLine("Your task list is full.");
        }
    }

    public static void MarkCompleted() {
        Console.WriteLine("Which task would you like to mark as completed (1, 2, or 3)?");
        int taskToComplete = int.Parse(Console.ReadLine());

        if (taskToComplete == 1 && !string.IsNullOrEmpty(task1)) 
        {
            task1Completed = true;
            Console.WriteLine("Task 1 marked as completed.");
        }
        else if (taskToComplete == 2 && !string.IsNullOrEmpty(task2)) 
        {
            task2Completed = true;
            Console.WriteLine("Task 2 marked as completed.");
        }
        else if (taskToComplete == 3 && !string.IsNullOrEmpty(task3)) 
        {
            task3Completed = true;
            Console.WriteLine("Task 3 marked as completed.");
        }
        else 
        {
            Console.WriteLine("Invalid task selection.");
        }
    }

    public static void DisplayTasks() {
        Console.WriteLine("Your Tasks:");
        if (!string.IsNullOrEmpty(task1)) 
        {
            Console.WriteLine(task1Completed ? "Task 1: " + task1 + " [Completed]" : "Task 1: " + task1 + " [Pending]");
        }
        if (!string.IsNullOrEmpty(task2)) 
        {
            Console.WriteLine(task2Completed ? "Task 2: " + task2 + " [Completed]" : "Task 2: " + task2 + " [Pending]");
        }
        if (!string.IsNullOrEmpty(task3)) 
        {
            Console.WriteLine(task3Completed ? "Task 3: " + task3 + " [Completed]" : "Task 3: " + task3 + " [Pending]");
        }
    }
}