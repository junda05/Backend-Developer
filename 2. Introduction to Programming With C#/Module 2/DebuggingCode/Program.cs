public class Program
{
    // Method to calculate the final price after a discount
    public static double ApplyDiscount(double price, double discountPercentage)
    {
        double discountAmount = price * (discountPercentage / 100);
        return price - discountAmount;
    }
    public static int FindMax(int[] numbers)
    {
        int max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    public static void Main()
    {
        double finalPrice = ApplyDiscount(1000, 15);
        Console.WriteLine("The final price is: " + finalPrice);

        int[] myNumbers = { -5, -10, -3, -8, -2 };
        int maxNumber = FindMax(myNumbers);
        Console.WriteLine("The maximum number is: " + maxNumber);
    }
}