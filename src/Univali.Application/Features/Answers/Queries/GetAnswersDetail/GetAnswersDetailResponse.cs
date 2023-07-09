using Univali.Api.Features.Common;

namespace Univali.Api.Features.Answers.Queries.GetAnswersDetail;

public class GetAnswersDetailResponse : BaseResponse
{
    public IEnumerable<GetAnswersDetailDto> AnswersDetailDtos {get;set;} = null!;

    public PaginationMetadata paginationMetadata = null!;
}