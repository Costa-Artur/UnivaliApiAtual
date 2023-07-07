namespace Univali.Api.Entities;

public class Question
{
    public int QuestionId {get; set;}
    public string Questioning {get; set;} = string.Empty;
    public DateTime CreationDate {get; set;}
    public DateTime LastUpdate {get; set;}
    public string Category {get; set;} = string.Empty;
    public List<Answer> Answers {get; set;} = new();
    public Lesson? Lesson {get; set;}
    public int LessonId {get; set;}
    public Student? Student {get; set;}
    public int StudentId {get; set;}    
}
