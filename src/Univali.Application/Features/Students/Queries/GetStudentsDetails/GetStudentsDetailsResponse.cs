using Univali.Api.Features.Common;

namespace Univali.Api.Features.Students.Queries.GetStudentsDetails;

public class GetStudentsDetailsResponse : BaseResponse
{
    public IEnumerable<GetStudentsDetailsDto> Students {get; set;} = default!;
}