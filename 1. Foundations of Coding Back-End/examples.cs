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

// Declare an array
int[] numbers = { 5, 5, 3, 2, 10, 1, 15, 2, 20 };
int maxNumber = 0;

for (int i = 0; i < numbers.Length - 1; i++)
    if (numbers[i] < numbers[i + 1])
    {
        maxNumber = numbers[i + 1];
    }

Console.WriteLine($"New max found: {maxNumber}");