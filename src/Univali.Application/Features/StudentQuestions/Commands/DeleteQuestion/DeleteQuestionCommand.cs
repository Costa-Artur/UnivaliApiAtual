using MediatR;

namespace Univali.Api.Features.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommand : IRequest<bool>
{
    public int QuestionId { get; set; }
    public int StudentId { get; set; }
}