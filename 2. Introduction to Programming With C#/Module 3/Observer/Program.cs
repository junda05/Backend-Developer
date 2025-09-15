// The Observer pattern defines a one-to-many relationship between objects. When one object (the subject) changes state, it notifies all registered observers.
    // The Subject class manages a list of IObserver instances and notifies them of changes.
    // This pattern is beneficial in scenarios like implementing event handling, where multiple objects need to be updated in response to an event.

public interface IObserver
{
    void Update(string message);
}

public class ConcreteObserver : IObserver
{
    private string name;

    public ConcreteObserver(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine($"{name} received message: {message}");
    }
}

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

public class Program
{
    public static void Main()
    {
        Subject subject = new Subject();

        IObserver observer1 = new ConcreteObserver("Observer 1");
        IObserver observer2 = new ConcreteObserver("Observer 2");

        subject.Attach(observer1);
        subject.Attach(observer2);

        subject.Notify("Hello, Observers!"); // Outputs: "Observer 1 received message: Hello, Observers!"
                                            //          "Observer 2 received message: Hello, Observers!"
    }
}