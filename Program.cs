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
                    var connectionString = "mongodb+srv://raduicadenisy9i:<db_password>@classroommanagementsyst.3sh4hru.mongodb.net/?retryWrites=true&w=majority&appName=ClassroomManagementSystem"; // Replace with your connection string
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase("ClassroomDB"); // Replace with your database name
                    
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
