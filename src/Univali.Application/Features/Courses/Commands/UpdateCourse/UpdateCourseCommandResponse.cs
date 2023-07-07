using Univali.Api.Features.Common;

namespace Univali.Api.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseCommandResponse : BaseResponse
{
    public bool Exist { get; set; }
}