public class Pool {
    public int chlorineLevel;
    public int waterLevel;
    public Pool(int chlorine, int water) {
        chlorineLevel = chlorine;
        waterLevel = water;
    }
    public void PoolInfo() {
        Console.WriteLine($"Pool: {chlorineLevel}, {waterLevel}");
    }
}

public class Spa : Pool {
    public int heatLevel;
    public Spa(int chlorine, int water, int heat)
        : base(chlorine, water)
    {
        heatLevel = heat;
    }
    public void SpaInfo() {
        Console.WriteLine($"Spa: {chlorineLevel}, {waterLevel}, {heatLevel}");
    }
}

// Polymorphism Example
public class Instrument {
    public virtual void Play() {
        Console.WriteLine("Playing an instrument");
    }
}


public class Piano : Instrument {
    public override void Play() {
        Console.WriteLine("The piano is playing");
    }
}

public interface IPlayable {
    void Play();
}

public class Guitar : IPlayable
{
    public void Play()
    {
        Console.WriteLine("The guitar is playing");
    }
}


// Create a base class called Animal and two derived classes Dog and Cat. This introduces you to the concept of inheritance, 
// where Dog and Cat inherit properties and methods from Animal.

// Define a base class Animal with a virtual method MakeSound.
// Create two derived classes Dog and Cat that inherit from Animal.
// Override the MakeSound method in each derived class.

public class Animal: IAnimal
{
    // Developers use polymorphism by creating a virtual method in the base class, which can be overridden in any derived class to provide specific behavior
    public virtual void MakeSound()
    {
        Console.WriteLine("Hi");
    }
    public void Eat()
    {
        Console.WriteLine("Eating");
    }
}

public class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Bark");
    }
    public void Eat()
    {
        Console.WriteLine("Kibble");
    }
}
public class Cat : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
    public void Eat()
    {
        Console.WriteLine("Tuna");
    }
}

// In the Main method, create instances of the Dog and Cat classes and then call the MakeSound method from instances of Dog and Cat.
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         Dog myDog = new Dog();
//         Cat myCat = new Cat();

//         myCat.MakeSound();
//         myDog.MakeSound();
//         myDog.Eat(); // Should print "Kibble"
//         myCat.Eat(); // Should print "Tuna"
//     }
// }

// Introduce interfaces to define a contract that classes can implement. Interfaces allow us to specify a set of methods that different classes must have.
public interface IAnimal
{
    void Eat();
}

// Use polymorphism to interact with objects of different classes through a common base type or interface. 
// This allows us to call methods on different objects in a unified way.
public class Program
{
    public static void Main(string[] args) {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Dog());
        animals.Add(new Cat());

        foreach (Animal animal in animals)
        {
            animal.MakeSound();
        }
    }
}