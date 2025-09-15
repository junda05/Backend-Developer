// Description: The Singleton pattern restricts the instantiation of a class to one "single" instance and provides a global point of access to it.

    // The Database class contains a private static instance variable and a private constructor to prevent multiple instances.
    // The GetInstance() method ensures that only one instance of Database is created using a double-check locking mechanism.
    // This pattern is useful for managing shared resources, like database connections, where only one instance should exist.
public class Database
{
    private static Database instance;
    private static readonly object lockObject = new object();

    // This is the constructor. Here, we define object's properties
    // Private constructor prevents instantiation from other classes. 
    private Database() { }

    public static Database GetInstance()
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new Database();
                }
            }
        }
        return instance;
    }

    public void Connect()
    {
        Console.WriteLine("Database connected.");
    }
}

public class Program
{
    public static void Main()
    {
        Database db1 = Database.GetInstance();
        Database db2 = Database.GetInstance();

        db1.Connect();
        Console.WriteLine(object.ReferenceEquals(db1, db2)); // Outputs: True
    }
}