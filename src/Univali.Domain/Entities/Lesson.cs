namespace Univali.Api.Entities;

public class Lesson
{
    public int LessonId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Module? Module { get; set; }
    public int ModuleId { get; set; }

    public List<Question> Questions { get; set; } = new();
}