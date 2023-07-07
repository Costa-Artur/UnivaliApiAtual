using MediatR;

namespace Univali.Api.Features.Questions.Queries.GetQuestionWithAnswers;

public class GetQuestionWithAnswersQuery : IRequest<GetQuestionWithAnswersDto>
{
        public int QuestionId { get; set; }
        public int StudentId { get; set; }
}