using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Queries.GetLessonQuestions;

public class GetLessonQuestionsQueryHandler : IRequestHandler<GetLessonQuestionsQuery, IEnumerable<GetLessonQuestionsDto>>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetLessonQuestionsQueryHandler(IMapper mapper, IPublisherRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<GetLessonQuestionsDto>> Handle(GetLessonQuestionsQuery request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.LessonExistsAsync(request.LessonId) 
        )
        {
            return null!;
        }

        var questionsFromDataBase = await _questionRepository.GetQuestionsByLessonIdAsync(request.LessonId);

        return _mapper.Map<IEnumerable<GetLessonQuestionsDto>>(questionsFromDataBase);
    }
}