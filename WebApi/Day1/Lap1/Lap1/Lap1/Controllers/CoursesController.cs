using Lap1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lap1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    { 
        
        AppDbContext _context;

        public CoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Courses
        [HttpGet]
        public IActionResult get()
        {
            var courses = _context.Courses.ToList();
            if (!courses.Any())
                return NotFound();           
            return Ok(courses);              
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();           
            return Ok(course);               
        }

        // GET: api/Courses/ByName/Python
        [HttpGet("ByName/{name}")]
        public IActionResult couseByName(string name)
        {
            var course = _context.Courses
                .FirstOrDefault(c => c.Crs_name == name);
            if (course == null)
                return NotFound();          // 404
            return Ok(course);              // 200 + course
        }

        // POST: api/Courses
        [HttpPost]
        public IActionResult post([FromBody] Course course)
        {
            if (course == null)
                return BadRequest();        // 400

            _context.Courses.Add(course);
            _context.SaveChanges();
            return StatusCode(201);         // 201 Created
        }

        // PUT: api/Courses/5
        [HttpPut("{id}")]
        public IActionResult put(int id, [FromBody] Course course)
        {
            if (id != course.ID)
                return BadRequest();        // 400

            var existing = _context.Courses.Find(id);
            if (existing == null)
                return NotFound();          // 404

            existing.Crs_name = course.Crs_name;
            existing.Crs_desc = course.Crs_desc;
            existing.Duration = course.Duration;
            _context.SaveChanges();
            return NoContent();             // 204
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public IActionResult deleteCourse(int id)
        {
            var course = _context.Courses.Find(id);
            if (course == null)
                return NotFound();          // 404

            _context.Courses.Remove(course);
            _context.SaveChanges();
            return Ok(_context.Courses.ToList()); // 200 + List
        }
    }
}