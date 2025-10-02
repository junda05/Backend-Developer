using System.Text.Json;

public class Program
{
    // Identify Serialization Risks and Implement Input Validation for Serialization
    public static string SerializeUserData(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
        {
            Console.WriteLine("Invalid data. Serialization aborted");
            return string.Empty;
        }
        // Use a Secure Library for Serialization
        user.EncryptData();
        return JsonSerializer.Serialize(user);
    }

    public static User? DeserializeUserData(string jsonData, bool isTrustedSource)
    {
        if (!isTrustedSource)
        {
            Console.WriteLine("Deserialization blocked: Untrusted source.");
            return null;
        }
        return JsonSerializer.Deserialize<User>(jsonData);
    }

    public static void Main()
    {
        User user = new User { Name = "Alice", Email = "alice@example.com", Password = "SecureP@ss123" };

        // Step 2: Serialization risks
        string serializedData = SerializeUserData(user);
        Console.WriteLine("Serialized Data:\n" + serializedData);

        // Step 3: Input validation

        // Step 5: Deserialize only from trusted sources
        string trustedSourceData = serializedData; // Assume this is from a trusted source
        User? deserializedUser = DeserializeUserData(trustedSourceData, isTrustedSource: true);

        if (deserializedUser != null)
        {
            Console.WriteLine("Deserialization successful for trusted source.");
            Console.WriteLine($"User: {deserializedUser.Name}, Email: {deserializedUser.Email}, Password: {deserializedUser.Password}");
            Console.WriteLine("Data Hash: " + deserializedUser.GenerateHash());
        }
    }
}