<<<<<<< HEAD
public class StudyGroup
{
    public int Id { get; set; }
    public string GroupName { get; set; } = "";

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public ICollection<User> Members { get; set; } = new List<User>();
}
=======
namespace LMSApp.Models
{
    public class StudyGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; } = "";

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<User> Members { get; set; } = new List<User>();
    }
}
>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7
