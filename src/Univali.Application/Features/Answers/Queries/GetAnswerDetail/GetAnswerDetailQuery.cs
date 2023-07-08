using MediatR;

namespace Univali.Api.Features.Answers.Queries.GetAnswerDetail;

public class GetAnswerDetailQuery : IRequest<GetAnswerDetailResponse>
{
    public int QuestionId {get; set;}
    public int AnswerId {get; set;}
}