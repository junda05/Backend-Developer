using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Person
{
    public required string UserName { get; set; }
    public required int UserAge { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Serialize example for testing
        var samplePerson = new Person { UserName = "Alice", UserAge = 30 };

        // Binary serialization
        using (var fs = new FileStream("person.dat", FileMode.Create))
        using (var writer = new BinaryWriter(fs))
        {
            writer.Write(samplePerson.UserName);
            writer.Write(samplePerson.UserAge);
        }
        Console.WriteLine("Binary serialization complete.");

        // Binary deserialization
        Person deserializedPerson;
        using (var fs = new FileStream("person.dat", FileMode.Open))
        using (var reader = new BinaryReader(fs))
        {
            deserializedPerson = new Person
            {
                UserName = reader.ReadString(),
                UserAge = reader.ReadInt32()
            };
        }

        Console.WriteLine($"Binary Deserialization - UserName: {deserializedPerson.UserName}, UserAge: {deserializedPerson.UserAge}");


        // XML deserialization
        var xmlData = "<Person><UserName>Bob</UserName><UserAge>30</UserAge></Person>";
        var serializer = new XmlSerializer(typeof(Person));

        using (var reader = new StringReader(xmlData))
        {
            var deserializedPerson2 = (Person?)serializer.Deserialize(reader);
            Console.WriteLine($"XML Deserialization - UserName: {deserializedPerson2?.UserName}, UserAge: {deserializedPerson2?.UserAge}");
        }

        // JSON deserialization
        var jsonData = "{\"UserName\": \"Charlie\", \"UserAge\": 45}";
        var deserializedPerson3 = JsonSerializer.Deserialize<Person>(jsonData);

        Console.WriteLine($"JSON Deserialization - UserName: {deserializedPerson3?.UserName}, UserAge: {deserializedPerson3?.UserAge}");

        try
        {
            var jsonData2 = "{\"UserName\": \"Dana\"}";
            var deserializedPerson4 = JsonSerializer.Deserialize<Person>(jsonData2);

            if (string.IsNullOrEmpty(deserializedPerson4?.UserName))
                throw new Exception("UserName is required");

            Console.WriteLine("Data Integrity Verified");
            Console.WriteLine($"UserName: {deserializedPerson4.UserName}, UserAge: {deserializedPerson4.UserAge}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during deserialization: {ex.Message}");
        }
    }
}