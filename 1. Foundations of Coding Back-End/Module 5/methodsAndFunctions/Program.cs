// Methods and Functions Practice - C# Console Application
// To run this project: cd "c:\Users\Administrador\Documents\Backend-Developer\1. Foundations of Coding Back-End\Module 5\methodsAndFunctions"; dotnet run

using System;			
public class Program {
	// Define the method
	public static void DisplayWelcomeMessage() {
		Console.WriteLine("Welcome to the Program!"); }
    
	// Define the method with a parameter
	public static void GreetUser(string name) {
		Console.WriteLine("Hello " + name + "!"); }

	// Define the method that returns a value
	public static int CalculateSum(int num1, int num2) {
		return num1 + num2; }
    
	// Define the method that returns a boolean
	public static bool IsPositive(int num) {
		if (num > 0) { return true; }
        else { return false; } }
    
    // Define the method that checks if the user is old enough to drive
	public static bool IsOldEnoughToDrive(int age) {
		if (age >= 18) { return true; }
        else { return false; } }

    // Call the method inside Main
    static void Main(string[] args) {
        // Call the DisplayWelcomeMessage method
        DisplayWelcomeMessage();

        // Call the GreetUser method
        GreetUser("Alice");

        // Call the CalculateSum method and print the result
        int sum = CalculateSum(5, 7);
        Console.WriteLine("Sum: " + sum);

        // Call the IsPositive method and print the result
        int number = 5;
        bool result = IsPositive(number);
        if (result) {
            Console.WriteLine("The number is positive."); }
        else {
            Console.WriteLine("The number is not positive."); }

        // Call the IsOldEnoughToDrive method after asking for the user's age
		Console.WriteLine("Enter your age:");
		int age = int.Parse(Console.ReadLine());
		bool canDrive = IsOldEnoughToDrive(age);
		if (canDrive) {
			Console.WriteLine("You are old enough to drive."); }
        else {
            Console.WriteLine("You are not old enough to drive."); }
    }

}