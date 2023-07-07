namespace Univali.Api.Features.Lessons.Queries.GetLessonDetail;

public class GetLessonDetailDto
{
    public int LessonId { get; set;}
    public string Title { get; set;} = string.Empty;
    public string Description { get; set;} = string.Empty;
    public int ModuleId { get; set; }
}