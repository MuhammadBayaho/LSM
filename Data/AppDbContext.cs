using Microsoft.EntityFrameworkCore;
using LMSApp.Models;

namespace LMSApp.Data
{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudyGroup> StudyGroups { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Courses)
            .WithOne(c => c.Instructor)
            .HasForeignKey(c => c.InstructorId);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.StudyGroups)
            .WithOne(g => g.Course)
            .HasForeignKey(g => g.CourseId);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Documents)
            .WithOne(d => d.Course)
            .HasForeignKey(d => d.CourseId);

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Assignments)
            .WithOne(a => a.Course)
            .HasForeignKey(a => a.CourseId);
    }
}
}
