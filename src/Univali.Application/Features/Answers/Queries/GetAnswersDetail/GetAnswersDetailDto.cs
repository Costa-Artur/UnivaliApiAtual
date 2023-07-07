namespace Univali.Api.Features.Answers.Queries.GetAnswersDetail;

public class GetAnswersDetailDto
{
    public int AnswerId {get; set;}
    public string Body {get; set;} = string.Empty;
    public int QuestionId {get; set;}
    public int AuthorId {get; set;}
}