using MediatR;

namespace Univali.Api.Features.Answers.Commands.CreateAnswer;

public class CreateAnswerCommand : IRequest<CreateAnswerCommandResponse>
{
    public string Body {get; set;} = string.Empty;
    public int QuestionId {get; set;}
    public int AuthorId {get; set;}
}