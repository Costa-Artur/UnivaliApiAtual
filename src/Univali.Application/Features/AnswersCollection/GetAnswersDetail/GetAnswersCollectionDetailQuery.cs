using MediatR;

namespace Univali.Api.Features.AnswersCollection.GetAnswersDetail;

public class GetAnswersCollectionDetailQuery : IRequest<GetAnswersCollectionDetailResponse>
{
    public int AuthorId {get; set;}
    public string SearchQuery {get; set;} = string.Empty;
    public int PageNumber {get;set;}
    public int PageSize{get;set;}
}