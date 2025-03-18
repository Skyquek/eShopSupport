namespace eShopSupport.Backend.Data;

public class Customer
{
    public int customer_id { get; set; }

    public required string FullName { get; set; }
}

public class MegaManager
{
    private List<string> userList = new List<string>();
    private string logFile = "log.txt";
    private Dictionary<string, string> config = new Dictionary<string, string>()
    {
        { "maxUsers", "100" },
        { "theme", "dark" }
    };

    private object connection; // Who knows what this is? It's just here.

    public MegaManager()
    {
        Console.WriteLine("MegaManager is ready to do everything!");
    }

    public void AddUser(string user)
    {
        if (userList.Count < int.Parse(config["maxUsers"]))
        {
            userList.Add(user);
            Console.WriteLine($"Added user: {user}");
        }
        else
        {
            Console.WriteLine("User limit reached.");
        }
    }

    public void RemoveUser(string user)
    {
        if (userList.Contains(user))
        {
            userList.Remove(user);
            Console.WriteLine($"Removed user: {user}");
        }
    }

    public void LogSomething(string message)
    {
        File.AppendAllText(logFile, $"{DateTime.Now}: {message}\n");
    }

    public void ConnectToDatabase()
    {
        connection = new object(); // This does nothing
        Console.WriteLine("Pretending to connect to a database...");
    }

    public void PrintConfig()
    {
        foreach (var kvp in config)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}
