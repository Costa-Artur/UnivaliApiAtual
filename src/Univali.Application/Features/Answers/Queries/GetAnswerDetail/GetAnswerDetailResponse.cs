using Univali.Api.Features.Common;

namespace Univali.Api.Features.Answers.Queries.GetAnswerDetail;

public class GetAnswerDetailResponse : BaseResponse
{
    public GetAnswerDetailDto Answer {get;set;} = new();
}