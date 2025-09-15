public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    // Define the Greet method
    public void Greet()
    {
        Console.WriteLine("Hello, my name is " + Name);
    }
}