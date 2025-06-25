namespace LMSApp.DTOs
{
    public class CreateCourseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; } // TODO: replace with authenticated user's ID
    }
}

