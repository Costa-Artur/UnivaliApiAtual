using Univali.Api.Features.Common;

namespace Univali.Api.Features.Courses.Commands.CreateCourse;

public class CreateCourseCommandResponse : BaseResponse
{
    public CreateCourseDto Course { get; set; } = default!;
}