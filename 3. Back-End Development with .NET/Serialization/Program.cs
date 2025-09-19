using Newtonsoft.Json;

public class Product {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<string> Tags { get; set; }
}

public class Program {
    public static void Main()
    {
        // Deserialize JSON to C# object
        string json = "{\"Name\": \"Laptop\", \"Price\": 999.99, \"Tags\": [\"Electronics\", \"Computers\"]}";
        Product product = JsonConvert.DeserializeObject<Product>(json);
        Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Tags: {string.Join(", ", product.Tags)}");

        // Serialize C# object to JSON
        Product newProduct = new Product
        {
            Name = "Smartphone",
            Price = 699.99m,
            Tags = new List<string> { "Electronics", "Mobile" },
        };
        string newJSON = JsonConvert.SerializeObject(newProduct, Formatting.Indented);
        Console.WriteLine($"Serialize JSON: \n{newJSON}");
    }       
}