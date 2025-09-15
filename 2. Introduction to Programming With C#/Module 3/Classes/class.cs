public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    // This is the constructor. Here, we define object's properties
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}