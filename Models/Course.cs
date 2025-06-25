<<<<<<< HEAD
public class Course
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public int InstructorId { get; set; }

    public User Instructor { get; set; }
    public ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
    public ICollection<Document> Documents { get; set; } = new List<Document>();
    public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
}
=======
namespace LMSApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int InstructorId { get; set; }

        public User Instructor { get; set; }
        public ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
        public ICollection<Document> Documents { get; set; } = new List<Document>();
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
    }
}
>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7
