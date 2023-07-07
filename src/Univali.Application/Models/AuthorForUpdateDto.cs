namespace Univali.Api.Models;

public class AuthorForUpdateDto
{
    public int AuthorId { get; set; }
    public string Name {get; set;} = string.Empty;
    public string CPF {get; set;} = string.Empty;
}