using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Queries.GetLessonQuestionWithAnswers;

public class GetLessonQuestionWithAnswersQueryHandler : IRequestHandler<GetLessonQuestionWithAnswersQuery, GetLessonQuestionWithAnswersDto>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetLessonQuestionWithAnswersQueryHandler(IMapper mapper, IPublisherRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<GetLessonQuestionWithAnswersDto> Handle(GetLessonQuestionWithAnswersQuery request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.LessonExistsAsync(request.LessonId))
        {
            return null!;
        }

        var questionFromDataBase = await _questionRepository.GetQuestionWithAnswersByIdAsync(request.QuestionId);

        if(questionFromDataBase == null) return null!;

        if(questionFromDataBase.LessonId != request.LessonId) return null!;

        return _mapper.Map<GetLessonQuestionWithAnswersDto>(questionFromDataBase);
    }
}