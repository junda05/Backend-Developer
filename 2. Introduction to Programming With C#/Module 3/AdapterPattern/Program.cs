// The Adapter pattern allows incompatible interfaces to work together by wrapping an existing class with a new interface.

    // The Adapter class implements the ITarget interface and contains an instance of the Adaptee class.
    // The Request() method in Adapter converts calls to SpecificRequest() from the Adaptee.
    // This pattern is useful when integrating third-party libraries that do not match the expected interface.

// Target interface
public interface ITarget
{
    void Request();
}

// Adaptee class
public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Specific request is called.");
    }
}

// Adapter class
public class Adapter : ITarget
{
    private Adaptee adaptee;

    public Adapter(Adaptee adaptee)
    {
        this.adaptee = adaptee;
    }

    public void Request()
    {
        // Convert the interface of Adaptee to the Target interface
        adaptee.SpecificRequest();
    }
}

public class Program
{
    public static void Main()
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        target.Request(); // Outputs: Specific request is called.
    }
}