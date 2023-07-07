using MediatR;

namespace Univali.Api.Features.Questions.Queries.GetLessonQuestion;

public class GetLessonQuestionQuery : IRequest<GetLessonQuestionDto>
{
        public int QuestionId { get; set; }
        public int LessonId { get; set; }
}