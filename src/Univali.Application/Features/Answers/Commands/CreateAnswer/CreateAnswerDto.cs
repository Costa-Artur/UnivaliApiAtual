namespace Univali.Api.Features.Answers.Commands.CreateAnswer;

public class CreateAnswerDto
{
    public int AnswerId {get; set;}
    public string Body {get; set;} = string.Empty;
    public int QuestionId {get; set;}
    public int AuthorId {get; set;}
}