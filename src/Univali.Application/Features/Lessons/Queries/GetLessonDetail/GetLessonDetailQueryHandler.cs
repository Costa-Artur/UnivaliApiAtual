using AutoMapper;
using FluentValidation;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Lessons.Queries.GetLessonDetail;

public class GetLessonDetailQueryHandler : IRequestHandler<GetLessonDetailQuery, GetLessonDetailResponse>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public GetLessonDetailQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<GetLessonDetailResponse> Handle(GetLessonDetailQuery request, CancellationToken cancellationToken)
    {
        var getLessonDetailResponse = new GetLessonDetailResponse();
        var lessonEntity = await _publisherRepository.GetLessonByIdAsync(request.LessonId);
        if (lessonEntity == null) return getLessonDetailResponse;
        getLessonDetailResponse.Lesson = _mapper.Map<GetLessonDetailDto>(lessonEntity);
        return getLessonDetailResponse;
    }
}