<<<<<<< HEAD
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; } = "";
    public string Email { get; set; } = "";
    public string PasswordHash { get; set; } = "";
    public string Role { get; set; } = "Student"; // or "Instructor"

    public ICollection<Course> Courses { get; set; } = new List<Course>();
    public ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
}  
=======
namespace LMSApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = "Student"; // or "Instructor"

        public ICollection<Course> Courses { get; set; } = new List<Course>();
        public ICollection<StudyGroup> StudyGroups { get; set; } = new List<StudyGroup>();
    }
}
>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7
