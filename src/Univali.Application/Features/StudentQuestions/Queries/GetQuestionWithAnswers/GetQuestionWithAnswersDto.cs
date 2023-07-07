using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Features.Questions.Queries.GetQuestionWithAnswers;

public class GetQuestionWithAnswersDto 
{
    public int QuestionId { get; set; }
    public string Questioning { get; set; } = string.Empty;
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public string Category { get; set; } = string.Empty;
    public List<AnswerDto> Answers{ get; set; } = new();
}