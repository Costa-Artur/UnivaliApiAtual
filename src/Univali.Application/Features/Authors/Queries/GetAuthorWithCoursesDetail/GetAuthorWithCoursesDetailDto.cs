using Univali.Api.Models;

namespace Univali.Api.Features.Authors.Queries.GetAuthorWithCoursesDetail;

public class GetAuthorWithCoursesDetailDto
{
    public int AuthorId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public List<CourseDto> Courses { get; set; } = new();
}