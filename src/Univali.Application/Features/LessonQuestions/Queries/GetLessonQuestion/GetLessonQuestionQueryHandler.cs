using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Queries.GetLessonQuestion;

public class GetLessonQuestionQueryHandler : IRequestHandler<GetLessonQuestionQuery, GetLessonQuestionDto>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetLessonQuestionQueryHandler(IMapper mapper, IPublisherRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<GetLessonQuestionDto> Handle(GetLessonQuestionQuery request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.LessonExistsAsync(request.LessonId))
        {
            return null!;
        }

        var questionFromDataBase = await _questionRepository.GetQuestionByIdAsync(request.QuestionId);

        if(questionFromDataBase == null) return null!;

        if(questionFromDataBase?.LessonId != request.LessonId) return null!;

        return _mapper.Map<GetLessonQuestionDto>(questionFromDataBase);
    }
}