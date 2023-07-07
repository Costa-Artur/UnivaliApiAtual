namespace Univali.Api.Models;

public class QuestionForUpdateDto
{
    public int QuestionId { get; set; }
    public string Questioning { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public int ClassId { get; set; }
    public int StudentId { get; set; }
}