namespace Univali.Api.Features.AnswersCollection.GetAnswersDetail;

public class GetAnswersCollectionDetailDto
{
    public int AnswerId {get; set;}
    public string Body {get; set;} = string.Empty;
    public int QuestionId {get; set;}
    public int AuthorId {get; set;}
}