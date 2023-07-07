using Univali.Api.Features.Common;
using Univali.Api.Features.Customers.Commands.CreateCustomer;

namespace Univali.Api.Features.Customers.Commands.UpdateCustomerWithAddresses;

public class UpdateCustomerWithAddressesCommandResponse : BaseResponse
{
    public bool Exist { get; set; }

    public CreateCustomerDto Customer {get; set;} = default!;

    public UpdateCustomerWithAddressesCommandResponse()
    {
        Exist = true;
    }
}