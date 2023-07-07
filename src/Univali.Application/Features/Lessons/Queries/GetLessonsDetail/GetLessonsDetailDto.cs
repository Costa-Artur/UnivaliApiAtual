using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Features.Lessons.Queries.GetLessonsDetail;


public class GetLessonsDetailDto
{
    public int LessonId {get; set;}
    public string Title {get; set;} = string.Empty;

    public string Description {get; set;} = string.Empty;

    public int ModuleId { get; set; }
}
