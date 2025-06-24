csharp
public class Document
{
    public int Id { get; set; }
    public string FileName { get; set; } = "";
    public string FilePath { get; set; } = "";

    public int CourseId { get; set; }
    public Course Course { get; set; }
}