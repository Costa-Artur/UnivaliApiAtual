using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Univali.Api.Features.Students.Commands.DeleteStudent;

// IRequest<> transforma a classe em uma Mensagem
// DeleteCustomerDto é o tipo que este comando espera receber de volta
public class DeleteStudentCommand : IRequest<bool>
{
    [Required(ErrorMessage = "You should fill out a Id")]
    public int Id {get; set;}
}