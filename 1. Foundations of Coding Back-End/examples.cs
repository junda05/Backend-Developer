// Identifying data types
string Myvariable = "Banano";
Type MyType = Myvariable.GetType();
Console.WriteLine(MyType);

// Checking data type compatibility
object MyObject = 123;
if (MyObject.GetType() == typeof(int))
{
    Console.WriteLine($"The variable {MyObject} is an integer");
}
else
{
    Console.WriteLine($"The variable {MyObject} is not an integer");
}

// Convert data types
string MyString = "456";
int number = int.Parse(MyString);
if (number.GetType() == typeof(int))
{
    Console.WriteLine($"The variable {number} is an integer");
}
else
{
    Console.WriteLine($"The variable {number} is not an integer");
}

string StringNumber = "7891011";
if (int.TryParse(StringNumber, out int result))
{
    Console.WriteLine($"Conversion successful: {result}");
}
else
{
    Console.WriteLine("Conversion failed");
}


// Write an algorithm to find the largest number in a given array of integers
// Solution 1
int[] numbers = { 5, 5, 3, 2, 10, 1, 15, 2, 20 };
int maxNumber = 0;

for (int i = 0; i < numbers.Length - 1; i++)
    if (numbers[i] < numbers[i + 1])
    {
        maxNumber = numbers[i + 1];
    }

Console.WriteLine($"New max found: {maxNumber}");

// Solution 2
int[] numbers2 = { 5, 5, 3, 2, 10, 1, 15, 2, 20 };
int largest = numbers2[0];

foreach (int number in numbers2)
{
    if (number > largest)
    {
        largest = number;
    }
}

Console.WriteLine("The largest number is: " + largest);

// Write an algorithm to check if a given number is even or odd.
int numberToCheck = 42;

if (numberToCheck % 2 == 0)
{
    Console.WriteLine("The number " + numberToCheck + " is even.");
}
else
{
    Console.WriteLine("The number " + numberToCheck + " is odd.");
}

// Write an algorithm that calculates the sum of all numbers in a given array of integers.
// Solution 1
int[] numbersToSum = { 1, 2, 3, 4, 5 };
int sum = 0;

for (int i = 0; i < numbersToSum.Length; i++)
    sum = numbersToSum[i] + sum;

Console.WriteLine("The total sum is " + sum);

// Solution 2
int sumTotal = 0;

foreach (int numberActual in numbersToSum)
{
    sumTotal += numberActual;
}

Console.WriteLine("The total sum is " + sumTotal);

// Write an algorithm to count the number of vowels (a, e, i, o, u) in a given string.
string Phrase = "Hola mundo";
int vowelCount = 0;

foreach (int letraActual in Phrase)
{
    if (letraActual == 'a' || letraActual == 'e' || letraActual == 'i' || letraActual == 'o' || letraActual == 'u')
    {
        vowelCount += 1;
    }
}

Console.WriteLine("The total sum of vowels is " + vowelCount);

// Allow or deny access if age < 18
Console.Write("Enter your age: ");
int age = int.Parse(Console.ReadLine());

if (age < 18 && age > 0)
{ Console.WriteLine("Access Denied, your age is " + age + " years old"); }

else if (age <= 0)
{ Console.WriteLine("Enter a valid number for age"); }

else { Console.WriteLine("Acces granted"); }

// ---------------------------------------------------------------------------------------------------------------------------------------
// ASSIGNMENT: You Try It! Control Structures

// Exercise 1: You are developing a program for a travel company to determine the ticket price based on the passenger's age. 
// The company offers discounted prices for children and seniors. The rules are:

// - Children (under 12) pay half price.
// - Adults (12 to 65) pay full price.
// - Seniors (over 65) get a 20% discount.

// Write a program using an if-else statement to determine which price a passenger will pay.
Console.Write("Enter patient's age: ");
int ageTicket = int.Parse(Console.ReadLine());

if (ageTicket < 12) { Console.WriteLine("Half price ticket."); }
else if (ageTicket >= 12 && ageTicket <= 65) { Console.WriteLine("Full price ticket."); }
else { Console.WriteLine("Senior discount ticket."); }

// Exercise 2: The travel company offers multiple travel modes: "Bus," "Train," and "Flight." Each mode has a different booking message. 
// Create a program using a switch statement to determine which mode of transportation the user selects.

Console.Write("Selec a travel mode: ");
string mode = Console.ReadLine();

switch (mode)
{
    case "Bus":
        Console.WriteLine("Booking a bus ticket.");
        break;
    case "Train":
        Console.WriteLine("Booking a train ticket.");
        break;
    case "Flight":
        Console.WriteLine("Booking a flight ticket.");
        break;
}
// ---------------------------------------------------------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------------------------------------------------------

// Nested if else statement: Allows to check multiple conditions by placing statements inside other if-else statements
// Chained if else statement: Includes else if. Allows to check multiple conditions without nesting them
string day = "Monday";
switch (day) {
    case "Monday":
    case "Wednesday":
        Console.WriteLine("Eat cereal");
        break;
}
// ---------------------------------------------------------------------------------------------------------------------------------------

// ---------------------------------------------------------------------------------------------------------------------------------------
// Exercise 1: You are tasked with developing a tax calculation system. The program must calculate the tax rate based on the user's 
// income and whether they are a resident or a non-resident. The tax rates are as follows:

// - If the income is less than $50,000, residents are taxed at 10%, and non-residents at 15%.
// - If the income is between $50,000 and $100,000, residents are taxed at 20%, and non-residents at 25%.
// - If the income is over $100,000, residents are taxed at 30%, and non-residents at 35%.

// Mi solución
Console.WriteLine("Enter you incomes: ");
double income = double.Parse(Console.ReadLine());

Console.WriteLine("Are you resident?: ");
string residentInput = Console.ReadLine();
bool residentOrNot = true;

double taxes = 0;

if (residentInput == "Yes") { residentOrNot = true; }
else { residentOrNot = false; }

if (income < 50000.0)
{
    if (residentOrNot == false)
    {
        taxes = income * 0.15;
        Console.WriteLine($"¡Hi non-resident!, your taxes are ${taxes} dolars");
    }
    else
    {
        taxes = income * 0.1;
        Console.WriteLine($"¡Hi resident!, your taxes are ${taxes} dolars");
    }
}
else if (income >= 50000.0 && income <= 100000.0){
    if (residentOrNot == false)
    {
        taxes = income * 0.25;
        Console.WriteLine($"¡Hi non-resident!, your taxes are ${taxes} dolars");
    }
    else
    {
        taxes = income * 0.2;
        Console.WriteLine($"¡Hi resident!, your taxes are ${taxes} dolars");
    }
}
else{
    if (residentOrNot == false)
    {
        taxes = income * 0.35;
        Console.WriteLine($"¡Hi non-resident!, your taxes are ${taxes} dolars");
    }
    else
    {
        taxes = income * 0.3;
        Console.WriteLine($"¡Hi resident!, your taxes are ${taxes} dolars");
    }        
}

// Solucion Coursera
// Step 1: Prompt the user for input
Console.WriteLine("Enter your income:");
double income = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Are you a resident? (yes/no):");
string residentInput = Console.ReadLine();
bool isResident = residentInput.ToLower() == "yes";

double taxRate = 0;
double tax;

// Step 2: Use advanced if-else statements to calculate tax
if (income < 50000) {
    if (isResident) {
        taxRate = 0.10;  // 10% tax for residents
    } else {
        taxRate = 0.15;  // 15% tax for non-residents
    }
} else if (income >= 50000 && income <= 100000) {
    if (isResident) {
        taxRate = 0.20;  // 20% tax for residents
    } else {
        taxRate = 0.25;  // 25% tax for non-residents
    }
} else {
    if (isResident) {
        taxRate = 0.30;  // 30% tax for residents
    } else {
        taxRate = 0.35;  // 35% tax for non-residents
    }
}


// Step 3: Calculate and print the tax
tax = income * taxRate;
Console.WriteLine("The tax is: $" + tax);


// Mi código refactorizado
Console.WriteLine("Enter you incomes: ");
double income = double.Parse(Console.ReadLine());

Console.WriteLine("Are you resident?: ");
string residentInput = Console.ReadLine();
bool isResident = residentInput.ToLower() == "yes";

double taxRate = 0;
double tax;

if (income < 50000) {
    if (isResident) {
        taxRate = 0.10;  // 10% tax for residents
    } else {
        taxRate = 0.15;  // 15% tax for non-residents
    }
} else if (income >= 50000 && income <= 100000) {
    if (isResident) {
        taxRate = 0.20;  // 20% tax for residents
    } else {
        taxRate = 0.25;  // 25% tax for non-residents
    }
} else {
    if (isResident) {
        taxRate = 0.30;  // 30% tax for residents
    } else {
        taxRate = 0.35;  // 35% tax for non-residents
    }
}

tax = income * taxRate;
if (isResident) {
    Console.WriteLine($"¡Hi resident!, your taxes are ${tax} dolars");
}
else
{
    Console.WriteLine($"¡Hi non-resident!, your taxes are ${tax} dolars");
}        

// Exercise 2:
// You are developing a program to help users choose a phone plan based on the amount of data they want and whether they need international 
// calling. The available plans are:

    // - Basic Plan: 2GB of data, no international calling.
    // - Standard Plan: 5GB of data, no international calling.
    // - Premium Plan: 10GB of data, with international calling.
    // - Elite Plan: Unlimited data, with international calling.

Console.WriteLine("Enter your data usage (in GB):");
double amountData = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Do you need international callings?: ");
string internationalCallingsInput = Console.ReadLine();
bool internationalCallings = internationalCallingsInput.ToLower() == "yes";

string plan = "";

switch (amountData)
{
    case 2:
        plan = "Basic Plan";
        Console.WriteLine("You are choosing the Basic Plan");
        break;
    case 5:
        plan = "Standard Plan";
        Console.WriteLine("You are choosing the Standard Plan");
        break;
    case 10:
        if (internationalCallings) {
            plan = "Premium Plan";
            Console.WriteLine("You are choosing the Premium Plan with International Calling");
        } else {
            plan = "Standard Plan";
            Console.WriteLine("You are choosing the Standard Plan");
        }
        break;
    case -1:
        plan = "Unlimited Plan";
        Console.WriteLine("You are choosing the Unlimited Plan with International Calling");
        break;

    default:
        Console.WriteLine("Invalid data request");
        break;
}
// ---------------------------------------------------------------------------------------------------------------------------------------
// Problem 1: Membership Fee Calculation System
// You are developing a program to calculate the membership fee for a gym. The fee depends on the user’s age and membership type:

// - For users under 18, the fee is $15 for a basic membership and $25 for a premium membership.
// - For users between 18 and 60, the fee is $30 for a basic membership and $50 for a premium membership.
// - For users over 60, the fee is $20 for a basic membership and $35 for a premium membership.

// Solucion mia 1
Console.WriteLine("Enter your age: ");
int age = int.Parse(Console.ReadLine());
double fee;

Console.WriteLine("Choose a membership (basic/premium)");
string inputMembership = Console.ReadLine();

if (age < 18)
{
    switch (inputMembership)
    {
        case "basic":
            fee = 15;
            Console.WriteLine($"Your fee is ${fee} dolars");
            break;

        case "premium":
            fee = 25;
            Console.WriteLine($"Your fee is ${fee} dolars");
            break;

        default:
            Console.WriteLine("Invalid plan");
            break;
    }
}
else if (age >= 18 && age <= 60)
{
    switch (inputMembership)
    {
        case "basic":
            fee = 30;
            Console.WriteLine($"Your fee is ${fee} dolars");
            break;

        case "premium":
            fee = 50;
            Console.WriteLine($"Your fee is ${fee} dolars");
            break;

        default:
            Console.WriteLine("Invalid plan");
            break;
    }
}
else if (age > 60)
{
    switch (inputMembership)
    {
        case "basic":
            fee = 20;
            Console.WriteLine($"Your fee is ${fee} dolars");
            break;

        case "premium":
            fee = 35;
            Console.WriteLine($"Your fee is ${fee} dolars");
            break;

        default:
            Console.WriteLine("Invalid plan");
            break;
    }
}
else { Console.WriteLine("Invalid data. Try again"); }

// Solucion mia 2
Console.WriteLine("Enter your age: ");
int age = int.Parse(Console.ReadLine());
double fee;

Console.WriteLine("Choose a membership (basic/premium)");
string inputMembership = Console.ReadLine();

if (age < 18)
{
    if (inputMembership == "basic") { fee = 15; }
    else if (inputMembership == "premium") { fee = 25; }
    else { Console.WriteLine("Invalid plan"); }
}

else if (age >= 18 && age <= 60)
{
    if (inputMembership == "basic") { fee = 30; }
    else if (inputMembership == "premium") { fee = 50; }
    else { Console.WriteLine("Invalid plan"); }
}

else if (age > 60)
{
    if (inputMembership == "basic") { fee = 20; }
    else if (inputMembership == "premium") { fee = 35; }
    else { Console.WriteLine("Invalid plan"); }
}

else { Console.WriteLine("Invalid data. Try again"); }

Console.WriteLine("Your membership fee is: $" + fee);

// Problem 2: Bank Account Management System
// You are developing a bank account management system. The program must manage different types of bank accounts 
// and apply the correct fees or interest rates based on the account type:

    // - Savings Account: Apply a 2% interest rate.
    // - Checking Account: Apply a $10 monthly fee.
    // - Business Account: Apply a 1% interest rate and a $20 monthly fee.
    // - For all other account types, display an error message.

// Step 1: Prompt the user to enter the account type
Console.WriteLine("What type of account are you opening? (savings/checking/business):");
string accountType = Console.ReadLine().ToLower();

// Step 2: Declare variables for interest rate and monthly fee
double interestRate = 0;
int monthlyFee = 0;

// Step 3: Use switch statement to determine account details based on account type
switch (accountType)
{
    case "savings":
        // Handle savings account: Apply 2% interest rate
        interestRate = 0.02;
        Console.WriteLine("Interest rate is 2%");
        break;

    case "checking":
        // Handle checking account: Apply $10 monthly fee
        monthlyFee = 10;
        Console.WriteLine("Monthly fee is $10");
        break;

    case "business":
        // Handle business account: Apply 1% interest rate and $20 monthly fee
        interestRate = 0.01;
        monthlyFee = 20;
        Console.WriteLine("Interest rate is 1% and monthly fee is $20");
        break;

    default:
        // Handle invalid account type
        Console.WriteLine("Invalid account type");
        break;
}