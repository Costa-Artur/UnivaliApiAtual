using MediatR;
using Univali.Api.Entities;

namespace Univali.Api.Features.Students.Commands.UpdateStudent;

// IRequest<> transforma a classe em uma Mensagem
// CreateCustomerDto é o tipo que este comando espera receber de volta
public class UpdateStudentCommand : IRequest<UpdateStudentCommandResponse>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // Pode ser CPF ou CNPJ
    public string CPF { get; set; } = string.Empty;
    public int Age { get; set; }
    // public AddressStudent? AddressStudent { get; set; }
}