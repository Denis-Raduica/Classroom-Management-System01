using MongoDB.Driver;
using ClassroomManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
var config = builder.Configuration;

// Set up MongoDB client and database using config values
var mongoClient = new MongoClient(config["MongoDB:ConnectionString"]);
var mongoDatabase = mongoClient.GetDatabase(config["MongoDB:DatabaseName"]);

// Register MongoDB services for dependency injection
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton(mongoDatabase);

// Add controllers (API endpoints)
builder.Services.AddControllers();

var app = builder.Build();

// Enable routing to controller endpoints
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();


// Start the application
app.Run();
