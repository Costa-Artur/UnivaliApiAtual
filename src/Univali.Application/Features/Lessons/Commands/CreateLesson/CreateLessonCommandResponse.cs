using Univali.Api.Features.Common;

namespace Univali.Api.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommandResponse : BaseResponse
{
    public CreateLessonCommandDto Lesson { get; set; } = default!;
}