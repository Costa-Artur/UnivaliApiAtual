using Univali.Api.Features.Common;

namespace Univali.Api.Features.Publishers.Commands.CreatePublisher;

public class CreatePublisherCommandResponse : BaseResponse
{
    public CreatePublisherDto Publisher { get; set; } = default!;
}