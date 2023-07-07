namespace Univali.Api.Models;

public class AnswerDto
{
    public int AnswerId { get; set; }
    public string Body { get; set; } = string.Empty;
    public int AuthorId { get; set; }
}