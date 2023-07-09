
using Univali.Api.Features.Common;

namespace Univali.Api.Features.AnswersCollection.GetAnswersDetail;

public class GetAnswersCollectionDetailResponse : BaseResponse
{
    public IEnumerable<GetAnswersCollectionDetailDto> AnswersDetailDtos {get;set;} = null!;

    public PaginationMetadata PaginationMetadata = null!;
}