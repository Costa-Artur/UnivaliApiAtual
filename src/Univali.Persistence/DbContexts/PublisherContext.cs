using Microsoft.EntityFrameworkCore;
using Univali.Api.Entities;
using Univali.Api.Extensions;

namespace Univali.Api.DbContexts;

public class PublisherContext : DbContext
{
    public DbSet<Publisher> Publishers { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<Module> Modules { get; set; } = null!;
    public DbSet<Lesson> Lessons { get; set; } = null!;
    public DbSet<Student> Students { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<Answer> Answers { get; set; } = null!;

    public PublisherContext(DbContextOptions<PublisherContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.PublisherInitFluentApi();
        modelBuilder.AuthorInitFluentApi();
        modelBuilder.CourseInitFluentApi();
        modelBuilder.ModuleInitFluentApi();
        modelBuilder.LessonInitFluentApi();
        modelBuilder.StudentInitFluentApi();
        modelBuilder.QuestionInitFluentApi();
        modelBuilder.AnswerInitFluentApi();

        modelBuilder.PublisherContextSeedData();

        base.OnModelCreating(modelBuilder);
    }
}