using Univali.Api.Features.Common;

namespace Univali.Api.Features.Addresses.Commands.CreateAddress;

public class CreateAddressCommandResponse : BaseResponse
{
    public CreateAddressDto Address { get; set;} = default!;
}