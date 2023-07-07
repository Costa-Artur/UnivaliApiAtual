using Univali.Api.Features.Common;
using Univali.Api.Features.Customers.Commands.CreateCustomer;

namespace Univali.Api.Features.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommandResponse : BaseResponse
{
    public bool Exist { get; set; }

    public CreateCustomerDto Customer {get; set;} = default!;

    public UpdateCustomerCommandResponse()
    {
        Exist = true;
    }
}