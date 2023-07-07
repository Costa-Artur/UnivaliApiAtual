namespace Univali.Api.Entities;

public class Answer
{
    public int AnswerId { get; set; }
    public string Body { get; set; } = string.Empty;
    public Question? Question { get; set; }
    public int QuestionId { get; set; }
    public Author? Author { get; set; }
    public int AuthorId { get; set; }
}