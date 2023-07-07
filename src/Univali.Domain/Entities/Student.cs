namespace Univali.Api.Entities;

public class Student
{
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;
    // Pode ser CPF ou CNPJ
    public string CPF { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateTime RegistrationDate { get; set; }
    public List<Question> Questions { get; set; } = new();
}