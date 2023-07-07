using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Lessons.Queries.GetLessonsDetail;

public class GetLessonsDetailQueryHandler : IRequestHandler<GetLessonsDetailQuery, IEnumerable<GetLessonsDetailDto>>
{
    private readonly IPublisherRepository _lessonRepository;
    private readonly IMapper _mapper;

    public GetLessonsDetailQueryHandler(IPublisherRepository lessonRepository, IMapper mapper)
    {
        _lessonRepository = lessonRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetLessonsDetailDto>> Handle(GetLessonsDetailQuery request, CancellationToken cancellationToken)
    {
        var lessonFromDatabase = await _lessonRepository.GetLessonsAsync();
        return _mapper.Map<IEnumerable<GetLessonsDetailDto>>(lessonFromDatabase);
    }
}