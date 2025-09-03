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