namespace Univali.Api.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionDto
{
    public int QuestionId { get; set; }
    public string Questioning { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public string Category { get; set; } = string.Empty;
}