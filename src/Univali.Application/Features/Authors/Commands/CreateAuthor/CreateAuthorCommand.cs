using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Univali.Api.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommand : IRequest<CreateAuthorCommandResponse>
{
    
    public string Name { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
}