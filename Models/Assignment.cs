<<<<<<< HEAD
public class Assignment
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public DateTime DueDate { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; }
}
=======
namespace LMSApp.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime DueDate { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7
