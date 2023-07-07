using Univali.Api.Features.Common;

namespace Univali.Api.Features.Authors.Commands.UpdateAuthor;

public class UpdateAuthorCommandResponse : BaseResponse
{
    public bool Exist { get; set; }
}