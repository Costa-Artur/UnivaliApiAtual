namespace Univali.Api.Features.Questions.Queries.GetQuestion;

public class GetQuestionDto 
{
    public int QuestionId { get; set; }
    public string Questioning { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public string Category { get; set; } = string.Empty;
}