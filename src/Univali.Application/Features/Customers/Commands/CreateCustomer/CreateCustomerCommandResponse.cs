using Univali.Api.Features.Common;

namespace Univali.Api.Features.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandResponse : BaseResponse
{
    public CreateCustomerDto Customer {get; set;} = default!;
}