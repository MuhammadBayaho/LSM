using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class AssignmentTests
{
    private AppDbContext GetContext()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new AppDbContext(options);
    }

    [Fact]
    public async Task Create_AddsAssignmentToDatabase()
    {
        using var context = GetContext();
        context.Courses.Add(new Course
        {
            Id = 1,
            Title = "Test Course",
            Description = "Desc",
            InstructorId = 1,
            Instructor = new User
            {
                FullName = "Instr",
                Email = "i@example.com",
                PasswordHash = "hash",
                Role = "Instructor"
            }
        });
        await context.SaveChangesAsync();
        var controller = new LMSApp.Controllers.AssignmentsController(context);
        var dto = new CreateAssignmentDto
        {
            Title = "Assign 1",
            Description = "Desc",
            DueDate = DateTime.UtcNow,
            CourseId = 1
        };

        var result = await controller.Create(dto);
        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        var assignment = Assert.IsType<Assignment>(createdResult.Value);
        Assert.Equal(1, assignment.CourseId);
        Assert.Equal(1, await context.Assignments.CountAsync());
    }
}
