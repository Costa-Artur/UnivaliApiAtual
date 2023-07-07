using Univali.Api.Entities;

namespace Univali.Api.Features.Students.Queries.GetStudentCollectionDetails;

public class GetStudentCollectionDetailsDto
{
    public int StudentId { get; set; }
    public string Name { get; set; } = string.Empty;
    // Pode ser CPF ou CNPJ
    public string CPF { get; set; } = string.Empty;
    public int Age { get; set; }
    public DateTime RegistrationDate { get; set; }
    // public AddressStudent? AddressStudent { get; set; }
}


public class AddressForGetStudentCollectionDetailsDto {
    public int AddressId { get; set;}
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
}