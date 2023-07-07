namespace Univali.Api.Models;

public class LessonForUpdateDto
{
    public int LessonId { get; set;}
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ModuleId { get; set; }   
}