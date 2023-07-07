using MediatR;

namespace Univali.Api.Features.Questions.Queries.GetQuestion;

public class GetQuestionQuery : IRequest<GetQuestionDto>
{
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
}