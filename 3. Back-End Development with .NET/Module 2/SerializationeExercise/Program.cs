using System;
using Newtonsoft.Json;

public class Person
{
    public required string Name { get; set; }
    public required int Age { get; set; }
}

public class Program
{
    public static void Main()
    {
        // JSON -> Objeto Person
        string json = "{\"Name\": \"John Doe\", \"Age\": 30}";
        Person person = JsonConvert.DeserializeObject<Person>(json)!;
        Console.WriteLine("Name: " + person.Name + ", Age: " + person.Age);

        // Objeto Person -> JSON
        Person newPerson = new Person
        {
            Name = "Ping Jeong",
            Age = 25
        };
        string newJson = JsonConvert.SerializeObject(newPerson);
        Console.WriteLine("Serialized JSON: " + newJson);
    }
}