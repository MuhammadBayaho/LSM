using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LMSApp.Data;
using LMSApp.Models;

namespace LMSApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DocumentsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // POST: api/documents/upload
        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm] IFormFile file, [FromForm] int courseId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file selected.");

            var course = await _context.Courses.FindAsync(courseId);
            if (course == null)
                return NotFound("Course not found.");

            var uploadsFolder = Path.Combine(_env.WebRootPath ?? "wwwroot", "documents");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var document = new Document
            {
                FileName = file.FileName,
                FilePath = $"/documents/{fileName}",
                CourseId = courseId
            };

            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Document uploaded successfully.", document });
        }

        // GET: api/documents/course/5
        [HttpGet("course/{courseId}")]
        public async Task<IActionResult> GetDocumentsForCourse(int courseId)
        {
            var documents = await _context.Documents
                .Where(d => d.CourseId == courseId)
                .ToListAsync();

            return Ok(documents);
        }

        // GET: api/documents/download/5
        [HttpGet("download/{id}")]
        public async Task<IActionResult> DownloadDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
                return NotFound();

            var fullPath = Path.Combine(_env.WebRootPath ?? "wwwroot", document.FilePath.TrimStart('/'));
            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found on server.");

            var fileBytes = await System.IO.File.ReadAllBytesAsync(fullPath);
            return File(fileBytes, "application/octet-stream", document.FileName);
        }
    }
}
