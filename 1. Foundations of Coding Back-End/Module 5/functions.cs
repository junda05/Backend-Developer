// Functions

// Write a function that calculates the area of a rectangle. 
// The function should accept two input parameters: the length and the width of the rectangle. 
// The program will prompt the user for these values, use the function to compute the area, and then display the result.

double CalculateRectangleArea(double length, double width) 
{
    return length * width; 
}

Console.WriteLine("Enter the length of the rectangle:");
double length = double.Parse(Console.ReadLine());
// Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the width of the rectangle:");
double width = Convert.ToDouble(Console.ReadLine());

double area = CalculateRectangleArea(length, width);
Console.WriteLine("The rectangle area is " + area + " m^2");

// Write a function that calculates the area of a triangle. The function should accept two input parameters: 
// the base and the height of the triangle. The program will prompt the user for these values, use the function 
// to compute the area, and then display the result.

double CalculateTriangleArea(double baseLength, double height) 
{
    return 0.5 * baseLength * height; 
}

Console.WriteLine("Enter the baseLength of the Triangle:");
double baseLength = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the height of the Triangle:");
double height = Convert.ToDouble(Console.ReadLine());

double TriangleArea = CalculateTriangleArea(baseLength, height);
Console.WriteLine("The triangle area is " + TriangleArea + " m^2");

// Write a function to calculate the area of a circle. The function should accept one input parameter: the radius of the circle. 
// The program should prompt the user for this value, use the function to compute the area, and then display the result.

string CalculateCircleArea(double radius)
{
    double squareRadius = Math.Pow(radius, 2);
    double CircleArea = Math.PI * squareRadius;
    return $"The circle area is {CircleArea} m^2";
}

Console.WriteLine("Enter the radius of the circle:");
double radius = Convert.ToDouble(Console.ReadLine());
string CircleArea = CalculateCircleArea(radius);
Console.WriteLine(CircleArea);

// Write a function to calculate the area of a trapezoid. The function should accept three input parameters: the length of the two parallel sides (a and b) and the height. 
// The program should prompt the user for these values, use the function to compute the area, and then display the result.
// Formula: The area of a trapezoid is given by (a + b) / 2 * height.

string CalculateTrapezoidArea(double lengthA, double lengthB, double HeighTrapezoid)
{
    double TrapezoidArea = (lengthA + lengthB) / (2 * HeighTrapezoid);
    return $"The trapezoid area is {TrapezoidArea} m^2";
}

Console.WriteLine("Enter the lengthA of the trapezoid:");
double lengthA = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the lengthB of the trapezoid:");
double lengthB = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the HeighTrapezoid of the trapezoid:");
double HeighTrapezoid = Convert.ToDouble(Console.ReadLine());

string TrapezoidArea = CalculateTrapezoidArea(lengthA, lengthB, HeighTrapezoid);
Console.WriteLine(TrapezoidArea);