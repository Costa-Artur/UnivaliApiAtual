using Univali.Api.Entities;
using Univali.Api.Features.Common;

namespace Univali.Api.Features.Lessons.Queries.GetLessonDetail;

public class GetLessonDetailResponse : BaseResponse
{
    public GetLessonDetailDto? Lesson { get; set; }
}