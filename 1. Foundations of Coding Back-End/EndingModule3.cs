// You are developing a program for a quiz system to calculate the total score of a student based on individual quiz scores. 
// The scores are stored in an array, and you need to use a for loop to sum them up.

    // - Define an array named scores containing the integers 85, 90, 78, 92, and 88.
    // - Use a for loop to iterate over each element in the array and calculate the total score.
    // - Print the total score using Console.WriteLine().

int[] scores = { 85, 90, 78, 92, 88 };
int totalScore = 0;

for (int i = 0; i < scores.Length; i++){
    totalScore += scores[i];}

totalScore /= scores.Length;
Console.WriteLine($"Average Score: {totalScore}");

// Create a program that calculates the factorial of a given number using a while loop. 
// The program should ask the user for an integer and then calculate its factorial.

    // - Declare an integer variable number and set its value to 5.
    // - Use a while loop to calculate the factorial of the number.
    // - After each iteration, decrement the value of number.
    // - Print the factorial using Console.WriteLine().

int number = 5;
int factorial = 1;

while (true){
    factorial *= number;
    number--;
    if (number <= 1) break;
}
Console.WriteLine($"Factorial: {factorial}");

// Write a program that uses a for loop with an if-else structure to check if each student's score meets the passing criteria. 
// A student passes if their score is 50 or above.

    // - Define an array named studentScores containing the integers 45, 60, 72, 38, and 55.
    // - Use a for loop to iterate over each element in the array.
    // - Inside the loop, use an if-else statement to check if the score is 50 or above.
    // - Print "Pass" if the score is 50 or above; otherwise, print "Fail."

int[] studentScores1 = { 45, 60, 72, 38, 55 };

for (int i = 0; i < studentScores1.Length; i++)
{
    if (studentScores1[i] >= 50) { Console.WriteLine(studentScores1[i] + " - Pass"); }
    else { Console.WriteLine(studentScores1[i] + " - Fail"); }
}

// Create a program that schedules weekly tasks using a switch statement inside a for loop to assign a task for each day.

    // - Define an array named weekDays containing the strings "Monday," "Tuesday," "Wednesday," "Thursday," "Friday."
    // - Use a for loop to iterate over each element in the array.
    // - Inside the loop, use a switch statement to assign a task to each day:
        // - If it's "Monday," print "Team Meeting."
        // - If it's "Tuesday," print "Code Review."
        // - If it's "Wednesday," print "Development."
        // - If it's "Thursday," print "Testing."
        // - If it's "Friday," print "Deployment."

string[] weekDays = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };

for (int i = 0; i < weekDays.Length; i++){
    switch (weekDays[i]){
        case "Monday":
            Console.WriteLine("Team Meeting.");
            break;
        case "Tuesday":
            Console.WriteLine("Code Review.");
            break;
        case "Wednesday":
            Console.WriteLine("Development.");
            break;
        case "Thursday":
            Console.WriteLine("Testing.");
            break;
        case "Friday":
            Console.WriteLine("Deployment.");
            break;
        default:
            Console.WriteLine("No task assigned.");
            break;}}

// Create a program that repeatedly asks the user to input a number between 1 and 10 and ensures the number is even. 
// The loop should continue until the user enters a valid input using an if-else statement to check the validity.

    // - Use a do-while loop to continuously prompt the user for an even number between 1 and 10.
    // - Inside the loop, use an if-else statement to validate whether the number is even and between 1 and 10.
    // - If the input is valid, print the number and exit the loop using the break statement. If it’s invalid, 
    //   display an error message and repeat the prompt.

int input;
do {
    Console.WriteLine("Enter an even number between 1 and 10:");
    input = int.Parse(Console.ReadLine());
    if (input >= 1 && input <= 10 && input % 2 == 0) {
        Console.WriteLine("Valid input: " + input);
        break;
    } else {
        Console.WriteLine("Invalid input. Please try again.");
    }
} while (true);

// Write a program that uses a for loop and an if-else structure to evaluate a list of student grades. For each grade, 
// determine whether the student has passed or failed based on the grade value.

    // - Define an array named grades containing a list of student grades.
    // - Use a for loop to iterate over each grade in the array.
    // - Inside the loop, use an if-else statement to check if each grade is greater than or equal to 65 (passing). 
    //   Print "Pass" if the grade is passing and "Fail" if it is not.

int[] grades = { 85, 92, 78, 64, 89 };

for (int i = 0; i < grades.Length; i++) {
    int grade = grades[i];
    string result;
    if (grade >= 65) {
        result = "Pass";
    } else {
        result = "Fail";
    }
    Console.WriteLine($"Score: {grade} Result: {result}");
}

// Create a program that processes multiple orders by their status. Each order can be "Pending," "Shipped," "Delivered," or "Cancelled," 
// and the program will print a message based on the status of each order.

    // - Define an array named orderStatuses containing different statuses: "Pending," "Shipped," "Delivered," and "Cancelled."
    // - Use a loop to iterate through the list of order statuses.
    // - Inside the loop, use a switch statement to print a different message based on the order’s status.

string[] orderStatuses = { "Pending", "Shipped", "Delivered", "Cancelled" };

for (int i = 0; i < orderStatuses.Length; i++) {
    string status = orderStatuses[i];
    switch (status) {
        case "Pending":
            Console.WriteLine("Order is pending.");
            break;
        case "Shipped":
            Console.WriteLine("Order has been shipped.");
            break;
        case "Delivered":
            Console.WriteLine("Order has been delivered.");
            break;
        case "Cancelled":
            Console.WriteLine("Order has been cancelled.");
            break;
        default:
            Console.WriteLine("Unknown status.");
            break;}}

// Write a program that uses a for loop to iterate over a list of student scores and a switch statement to assign letter grades based on the score.

    // - Define an array of student scores.
    // - Use a for loop to iterate through each score.
    // - Inside the loop, use a switch statement to assign a letter grade (A, B, C, D, F) based on the score.

int[] scores2 = { 95, 82, 75, 63, 58 };

for (int i = 0; i < scores2.Length; i++) {
    int score2 = scores2[i];
    switch (score2) {
        case int n when (n >= 90):
            Console.WriteLine("Grade A: Excellent!");
            break;
        case int n when (n >= 80):
            Console.WriteLine("Grade B: Good job!");
            break;
        case int n when (n >= 70):
            Console.WriteLine("Grade C: Fair.");
            break;
        case int n when (n >= 60):
            Console.WriteLine("Grade D: Needs improvement.");
            break;
        default:
            Console.WriteLine("Grade F: Fail.");
            break;}}