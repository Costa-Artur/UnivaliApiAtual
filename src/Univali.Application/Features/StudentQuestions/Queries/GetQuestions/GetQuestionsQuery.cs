using MediatR;

namespace Univali.Api.Features.Questions.Queries.GetQuestions;

public class GetQuestionsQuery : IRequest<IEnumerable<GetQuestionsDto>>
{
        public int StudentId { get; set; }
}