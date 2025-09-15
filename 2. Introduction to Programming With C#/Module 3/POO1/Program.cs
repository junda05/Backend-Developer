// Without constructor in Person class in class.cs (compare with POO2)

public class Program
{
    public static void Main(string[] args)
    {
        // Create the first Person object
        Person friend = new Person();
        friend.Name = "John Doe";
        friend.Age = 30;

        // Create the second Person object
        Person colleague = new Person();
        colleague.Name = "Jane Smith";
        colleague.Age = 25;

        // Call the Greet method on each object
        friend.Greet(); // Output: Hello, my name is John Doe
        colleague.Greet(); // Output: Hello, my name is Jane Smith
    }
}