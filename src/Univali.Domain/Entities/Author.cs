namespace Univali.Api.Entities;

public class Author
{
    public int AuthorId {get; set;}
    public string Name {get; set;} = string.Empty;
    public string CPF {get; set;} = string.Empty;
    public List<Course> Courses {get; set;} = new();
    public List<Answer> Answers {get; set;} = new();
}