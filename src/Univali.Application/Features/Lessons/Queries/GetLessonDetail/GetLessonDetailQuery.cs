using MediatR;

namespace Univali.Api.Features.Lessons.Queries.GetLessonDetail;

public class GetLessonDetailQuery : IRequest<GetLessonDetailResponse>
{
    public int LessonId { get; set; }
}