using MediatR;

namespace Univali.Api.Features.Lessons.Queries.GetLessonsDetail;

public class GetLessonsDetailQuery : IRequest<IEnumerable<GetLessonsDetailDto>>
{
}