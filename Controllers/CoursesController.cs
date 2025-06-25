using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMSApp.Data;
using LMSApp.Models;
using LMSApp.DTOs;

namespace LMSApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _context.Courses
            .Include(c => c.Instructor)
            .ToListAsync();

        return Ok(courses);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(int id)
    {
        var course = await _context.Courses
            .Include(c => c.Instructor)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDto dto)
    {
        var instructor = await _context.Users.FindAsync(dto.InstructorId);
        if (instructor == null || instructor.Role != "Instructor")
            return BadRequest("Instructor not found or role mismatch.");

        var course = new Course
        {
            Title = dto.Title,
            Description = dto.Description,
            InstructorId = dto.InstructorId
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCourseById), new { id = course.Id }, course);
    }
    }
}
