using MediatR;

namespace Univali.Api.Features.Answers.Commands.UpdateAnswer;

public class UpdateAnswerCommand : IRequest<UpdateAnswerCommandResponse>
{
    public int AnswerId {get; set;}
    public string Body {get; set;} = string.Empty;
    public int QuestionId {get; set;}
    public int AuthorId {get; set;}
}