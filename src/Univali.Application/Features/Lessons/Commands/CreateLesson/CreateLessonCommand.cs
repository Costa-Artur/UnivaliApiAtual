using MediatR;

namespace Univali.Api.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommand : IRequest<CreateLessonCommandResponse>
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ModuleId { get; set; }
}