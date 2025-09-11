// Write a method that adds two numbers and returns the result. The method should take two integer parameters.
// cd "c:\Users\Administrador\Documents\Backend-Developer\1. Foundations of Coding Back-End\Module 5\methods"; dotnet run
public class Program
{
    public static void Main()
    {

        Console.WriteLine("Enter the first number:");
        int num1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the second number:");
        int num2 = Convert.ToInt32(Console.ReadLine());

        int result = AddNumbers(num1, num2);

        Console.WriteLine("The sum of the numbers is: " + result);
    }
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }
}

// Write a method to calculate the discount on a product. The method should take two parameters: 
// the original price and the discount rate, and return the final price after applying the discount.
// public class Program {
//     public static void Main(){
//         Console.WriteLine("Enter the original price:");
//         decimal originalPrice = Convert.ToDecimal(Console.ReadLine());

//         Console.WriteLine("Enter the discount rate (as a decimal, e.g., 0.20 for 20%):");
//         decimal discountRate = Convert.ToDecimal(Console.ReadLine());

//         decimal finalPrice = CalculateDiscount(originalPrice, discountRate);
//         Console.WriteLine("The final price after discount is: " + finalPrice);}

//     static decimal CalculateDiscount(decimal originalPrice, decimal discountRate){
//         return originalPrice * (1 - discountRate);}}

// // Circle Area
// public class Program {
//     public static void Main() {
//         Console.WriteLine("Enter the radius of the circle:");
//         double radius = Convert.ToDouble(Console.ReadLine());
//         string CircleArea = CalculateCircleArea(radius);
//         Console.WriteLine(CircleArea); }

//         static string CalculateCircleArea(double radius)
//         {
//             double squareRadius = Math.Pow(radius, 2);
//             double CircleArea = Math.PI * squareRadius;
//             return $"The circle area is {CircleArea} m^2"; }}

// // Trapezoid Area
// public class Program
// {
//     public static void Main()
//     {
//         Console.WriteLine("Enter the lengthA of the trapezoid:");
//         double lengthA = Convert.ToDouble(Console.ReadLine());

//         Console.WriteLine("Enter the lengthB of the trapezoid:");
//         double lengthB = Convert.ToDouble(Console.ReadLine());

//         Console.WriteLine("Enter the HeighTrapezoid of the trapezoid:");
//         double HeighTrapezoid = Convert.ToDouble(Console.ReadLine());

//         string TrapezoidArea = CalculateTrapezoidArea(lengthA, lengthB, HeighTrapezoid);
//         Console.WriteLine(TrapezoidArea);
//     }

//     static string CalculateTrapezoidArea(double lengthA, double lengthB, double HeighTrapezoid)
//     {
//         double TrapezoidArea = (lengthA + lengthB) / (2 * HeighTrapezoid);
//         return $"The trapezoid area is {TrapezoidArea} m^2";
//     }
// }