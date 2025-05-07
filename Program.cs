using MongoDB.Driver;
using ClassroomManagementSystem.Models;
using Classroom_Management_System.Services;

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

app.Lifetime.ApplicationStarted.Register(async () =>
{
    using var scope = app.Services.CreateScope();
    var service = scope.ServiceProvider.GetRequiredService<CourseService>();

    var existingCourses = await service.GetAsync();
    if (!existingCourses.Any())
    {
        await service.CreateAsync(new Course
        {
            Name = "Mathematics 101",
            Description = "Intro to Algebra and Calculus",
            TeacherId = "teacher1"
        });

        await service.CreateAsync(new Course
        {
            Name = "History of Art",
            Description = "Explore art history from ancient to modern",
            TeacherId = "teacher2"
        });

        await service.CreateAsync(new Course
        {
            Name = "Physics - Mechanics",
            Description = "Fundamentals of classical mechanics",
            TeacherId = "teacher3"
        });
    }
});


// Start the application
app.Run();
