using MediatR;

namespace Univali.Api.Features.Answers.Queries.GetAnswersDetail;

public class GetAnswersDetailQuery : IRequest<GetAnswersDetailResponse>
{
    public int QuestionId {get; set;}
}