using MediatR;
using Univali.Api.Features.Common;

namespace Univali.Api.Features.Answers.Queries.GetAnswersDetail;

public class GetAnswersDetailQuery : IRequest<GetAnswersDetailResponse>
{
    public int QuestionId {get; set;}
    public int PageNumber {get;set;}
    public int PageSize{get;set;}
}