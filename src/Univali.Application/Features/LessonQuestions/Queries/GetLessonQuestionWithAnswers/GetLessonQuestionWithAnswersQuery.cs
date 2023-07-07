using MediatR;

namespace Univali.Api.Features.Questions.Queries.GetLessonQuestionWithAnswers;

public class GetLessonQuestionWithAnswersQuery : IRequest<GetLessonQuestionWithAnswersDto>
{
        public int QuestionId { get; set; }
        public int LessonId { get; set; }
}