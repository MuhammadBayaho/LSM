<<<<<<< HEAD
public class Document
{
    public int Id { get; set; }
    public string FileName { get; set; } = "";
    public string FilePath { get; set; } = "";

    public int CourseId { get; set; }
    public Course Course { get; set; }
}
=======
namespace LMSApp.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string FileName { get; set; } = "";
        public string FilePath { get; set; } = "";

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
>>>>>>> dbe7ede0baee7e9b1efa70f6d723820a0bc80ad7
