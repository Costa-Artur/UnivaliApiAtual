using Univali.Api.Features.Common;

namespace Univali.Api.Features.Students.Queries.GetStudentCollectionDetails;

public class GetStudentCollectionDetailsResponse : BaseResponse
{
    public IEnumerable<GetStudentCollectionDetailsDto> StudentCollection {get; set;} = default!;
}