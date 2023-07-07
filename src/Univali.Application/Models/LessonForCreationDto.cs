namespace Univali.Api.Models;

public class LessonForCreationDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ModuleId { get; set; }
}