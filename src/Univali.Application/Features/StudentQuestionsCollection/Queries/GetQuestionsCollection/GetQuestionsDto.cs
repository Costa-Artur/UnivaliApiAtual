namespace Univali.Api.Features.QuestionsCollection.Queries.GetQuestionsCollection;

public class GetQuestionsCollectionDto 
{
    public int QuestionId { get; set; }
    public string Questioning { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
}