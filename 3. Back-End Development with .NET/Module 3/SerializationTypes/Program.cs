using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;

public class Person {
    public required string UserName { get; set; }
    public int UserAge { get; set; }
}

class Program {
    static void Main() {
        Person samplePerson = new Person { UserName = "Alice", UserAge = 30 };
        using (FileStream fs = new FileStream("person.dat", FileMode.Create))
        {
            BinaryWriter writer = new BinaryWriter(fs);
            writer.Write(samplePerson.UserName);
            writer.Write(samplePerson.UserAge);
        }
        Console.WriteLine("Binary Serializarion complete.");


        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));

        using (StreamWriter writer = new StreamWriter("person.xml"))
        {
            xmlSerializer.Serialize(writer, samplePerson);
        }
        Console.WriteLine("XML Serializarion complete.");


        string jsonString = JsonSerializer.Serialize(samplePerson);

        File.WriteAllText("person.json", jsonString);

        Console.WriteLine("JSON serialization complete.");
    }
}