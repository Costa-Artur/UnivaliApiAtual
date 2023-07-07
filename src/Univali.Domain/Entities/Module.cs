namespace Univali.Api.Entities;

public class Module{
    public int ModuleId { get; set;}
    public List<Lesson> Lessons { get; set;} = new();
}