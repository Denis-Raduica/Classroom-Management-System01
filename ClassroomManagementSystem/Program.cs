using MongoDB.Driver;
using ClassroomManagementSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Load configuration from appsettings.json
var config = builder.Configuration;

// Set up MongoDB client and database using config values
var mongoClient = new MongoClient(config["MongoDB:ConnectionString"]);
var mongoDatabase = mongoClient.GetDatabase(config["MongoDB:DatabaseName"]);

// Access the "Courses" collection
var coursesCollection = mongoDatabase.GetCollection<Course>("Courses");

// Add controllers (API endpoints)
builder.Services.AddControllers();

var app = builder.Build();

// Enable routing to controller endpoints
app.MapControllers();
app.UseDefaultFiles();
app.UseStaticFiles();

// Seed database with courses on application startup
app.Lifetime.ApplicationStarted.Register(async () =>
{
    // Check if there are any existing courses
    var existingCourses = await coursesCollection.Find(course => true).ToListAsync();
    if (!existingCourses.Any())
    {
        // If no courses, seed some courses
        await coursesCollection.InsertOneAsync(new Course
        {
            Title = "Mathematics 101",
            Description = "Intro to Algebra and Calculus",
            Teacher = "teacher1"
        });

        await coursesCollection.InsertOneAsync(new Course
        {
            Title = "History of Art",
            Description = "Explore art history from ancient to modern",
            Teacher = "teacher2"
        });

        await coursesCollection.InsertOneAsync(new Course
        {
            Title = "Physics - Mechanics",
            Description = "Fundamentals of classical mechanics",
            Teacher = "teacher3"
        });
    }
});

// Start the application
app.Run();
