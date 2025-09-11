// Write a method that calculates the volume of a rectangular box. The method should accept three integer parameters: 
// length, width, and height. The method should return the volume calculated as:

// Volume = length * width * height.

static int CalculateVolumeBox(int length, int width, int height)
{
    int volume = length * width * height;
    return volume;
}

Console.WriteLine("Enter the length of the rectangular box");
int length = int.Parse(Console.ReadLine());
Console.WriteLine("Enter the width of the rectangular box");
int width = int.Parse(Console.ReadLine());
Console.WriteLine("Enter the height of the rectangular box");
int height = int.Parse(Console.ReadLine());

int volume = CalculateVolumeBox(length, width, height);
Console.WriteLine($"The volume of the rectangular box is {volume} m^3");

// Write a method that calculates the average of three integer numbers. The method should accept three parameters: 
// num1, num2, and num3. The method should return the average as an integer.
static int CalculateAverage(int num1, int num2, int num3)
{
    int average = (num1 + num2 + num3) / 3;
    return average;
}

Console.WriteLine("Enter number 1");
int num1 = int.Parse(Console.ReadLine());
Console.WriteLine("Enter number 2");
int num2 = int.Parse(Console.ReadLine());
Console.WriteLine("Enter number 3");
int num3 = int.Parse(Console.ReadLine());

int average = CalculateAverage(num1, num2, num3);
Console.WriteLine($"Average of the three numbers is {average}");