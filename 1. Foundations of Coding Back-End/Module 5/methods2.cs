// dotnet script methods2.cs

// Create a method that performs a task and call it in a program. This method should print a welcome message to the console.

    // - Define a method named DisplayWelcomeMessage that prints "Welcome to our Program!" to the console.
    // - Call the method to display the message.
    
static void DisplayWelcomeMessage()
{
    Console.WriteLine("Welcome to our Program!");
}

// Call the DisplayWelcomeMessage method
DisplayWelcomeMessage();

// Create a method that accepts a parameter to make the method more flexible and reusable. This method should greet a user with a personalized message.

    // - Define a method GreetUser that accepts a string parameter called name and prints a personalized message like "Hello [name]!".
    // - Call this method and pass a name as an argument.

static void GreetUser(string name){
    Console.WriteLine($"Hello {name}!");
}

string name = "Mauricio";
GreetUser(name);

// Create a method that returns a value. This method should calculate the sum of two numbers and return the result.

    // - Define a method CalculateSum that takes two integer parameters and returns their sum.
    // - Call the method passing two numbers and print the result.

static int CalculateSum(int a, int b)
{
    return a + b;
}

int sum = CalculateSum(5, 7);
Console.WriteLine($"The total sum is: {sum}");


// Create a method that returns a bool value based on a condition. This method should check if a number is positive.

    // - Define a method IsPositive that takes an integer as a parameter and returns a bool indicating whether the number is positive.
    // - Call the method and print whether the number is positive or not.

static bool IsPositive(int number) {
    if (number > 0){ return true; }
    else { return false; }
}

int number = 5;
bool EsPositivo = IsPositive(number);

if (EsPositivo) {
    Console.WriteLine("Number is positive");
}
else {
    Console.WriteLine("Number is negative");
}

// Create a program to validate user input using methods. This program should ask for the user’s age and check if they are old enough to drive.

    // - Define a method IsOldEnoughToDrive that takes an integer (age) and returns a bool indicating whether the person is old enough to drive.
    // - Call the method after asking for the user’s age and display an appropriate message.

static bool IsOldEnoughToDrive(int age)
{
    if (age >= 18) { return true; }
    else { return false; }
}

Console.WriteLine("Enter your age: ");
int age = int.Parse(Console.ReadLine());
bool isOlder = IsOldEnoughToDrive(age);

if (isOlder) {
    Console.WriteLine("You are allowed to drive");
}
else {
    Console.WriteLine("You are not allowed to drive");
}