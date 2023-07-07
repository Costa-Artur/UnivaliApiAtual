using Univali.Api.Features.Common;

namespace Univali.Api.Features.Authors.Commands.CreateAuthor;

public class CreateAuthorCommandResponse : BaseResponse
{
    public CreateAuthorDto Author { get; set; } = default!;
}