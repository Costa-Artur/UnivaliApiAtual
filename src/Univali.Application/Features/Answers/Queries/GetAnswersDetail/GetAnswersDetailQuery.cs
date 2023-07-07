using MediatR;

namespace Univali.Api.Features.Answers.Queries.GetAnswersDetail;

public class GetAnswersDetailQuery : IRequest<IEnumerable<GetAnswersDetailDto>>
{
    public int QuestionId {get; set;}
}