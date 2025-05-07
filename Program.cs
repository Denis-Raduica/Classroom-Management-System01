using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace ClassroomManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    // Test MongoDB connection
                    var connectionString = "your_mongo_connection_string"; // Replace with your connection string
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase("your_database_name"); // Replace with your database name
                    
                    try
                    {
                        // Attempt to connect to the MongoDB
                        var command = new BsonDocument("ping", 1);
                        database.RunCommandAsync(command).Wait();
                        Console.WriteLine("MongoDB connection successful");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("MongoDB connection failed: " + ex.Message);
                    }
                });
    }
}
