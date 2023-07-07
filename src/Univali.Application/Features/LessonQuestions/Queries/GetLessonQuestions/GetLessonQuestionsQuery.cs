using MediatR;

namespace Univali.Api.Features.Questions.Queries.GetLessonQuestions;

public class GetLessonQuestionsQuery : IRequest<IEnumerable<GetLessonQuestionsDto>>
{
        public int LessonId { get; set; }
}