using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ClassroomManagementSystem.Models;

namespace ClassroomManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly IMongoCollection<Course> _courses;

        public CoursesController(IMongoDatabase database)
        {
            _courses = database.GetCollection<Course>("Courses");
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _courses.Find(_ => true).ToListAsync();
            return Ok(courses);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] Course course)
        {
            await _courses.InsertOneAsync(course);
            return CreatedAtAction(nameof(GetCourses), new { id = course.Id }, course);
        }
    }
}
