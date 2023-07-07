using MediatR;

namespace Univali.Api.Features.Answers.Commands.DeleteAnswer;

public class DeleteAnswerCommand : IRequest<bool>
{
    public int AnswerId {get; set;}
    public int QuestionId {get; set;}
}