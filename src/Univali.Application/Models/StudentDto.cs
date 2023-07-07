using Univali.Api.Entities;

namespace Univali.Api.Models
{
   public class StudentDto
   {
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;
    // Pode ser CPF ou CNPJ
    public string CPF { get; set; } = string.Empty;
    public int Age { get; set; }
   //  public AddressStudent? AddressStudent { get; set; }
    public DateTime RegistrationDate { get; set; }
   }
}