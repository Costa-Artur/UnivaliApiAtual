using Univali.Api.Features.Common;
using Univali.Api.Features.Customers.Commands.CreateCustomerWithAddresses;

namespace Univali.Api.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerWithAddressesCommandResponse : BaseResponse
{
    public CreateCustomerWithAddressesDto Customer {get; set;} = default!;
}