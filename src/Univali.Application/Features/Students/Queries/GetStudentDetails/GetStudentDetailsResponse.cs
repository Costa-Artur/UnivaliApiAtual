using Univali.Api.Features.Common;

namespace Univali.Api.Features.Students.Queries.GetStudentDetails;

public class GetStudentDetailsResponse : BaseResponse
{
    public GetStudentDetailsDto Student {get; set;} = default!;
}