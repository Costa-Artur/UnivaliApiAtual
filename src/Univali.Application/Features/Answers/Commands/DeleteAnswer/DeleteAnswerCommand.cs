using MediatR;

namespace Univali.Api.Features.Answers.Commands.DeleteAnswer;

public class DeleteAnswerCommand : IRequest<DeleteAnswerCommandResponse>
{
    public int AnswerId {get; set;}
    public int QuestionId {get; set;}
}