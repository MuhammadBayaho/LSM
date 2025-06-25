public class StudyGroup
{
    public int Id { get; set; }
    public string GroupName { get; set; } = "";

    public int CourseId { get; set; }
    public Course Course { get; set; }

    public ICollection<User> Members { get; set; } = new List<User>();
}