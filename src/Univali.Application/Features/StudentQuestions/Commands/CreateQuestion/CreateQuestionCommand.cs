using MediatR;

namespace Univali.Api.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionCommand : IRequest<CreateQuestionCommandResponse>
{
    public string Questioning { get; set; } = string.Empty;
     public DateTime CreationDate { get; set; }
    public string Category { get; set; } = string.Empty;
    public int LessonId { get; set; }
    public int StudentId { get; set; }
}