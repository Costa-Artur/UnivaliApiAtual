using Univali.Api.Features.Common;

namespace Univali.Api.Features.Lessons.Commands.UpdateLesson;

public class UpdateLessonCommandResponse : BaseResponse
{
    public bool NotFound { get; set; }

    public UpdateLessonCommandResponse()
    {
        NotFound = false;
    }
}