using MediatR;

namespace Univali.Api.Features.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommand : IRequest<UpdateQuestionCommandResponse>
{
    public int QuestionId { get; set; }
    public string Questioning { get; set; } = string.Empty;
    public DateTime LastUpdate { get; set; }
    public string Category { get; set; } = string.Empty;
    public int LessonId { get; set; }
    public int StudentId { get; set; }
}