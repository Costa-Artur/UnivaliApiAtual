using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Queries.GetQuestions;

public class GetQuestionsQueryHandler : IRequestHandler<GetQuestionsQuery, IEnumerable<GetQuestionsDto>>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionsQueryHandler(IMapper mapper, IPublisherRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<GetQuestionsDto>> Handle(GetQuestionsQuery request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.StudentExistsAsync(request.StudentId) 
        )
        {
            return null!;
        }

        var questionsFromDataBase = await _questionRepository.GetQuestionsByStudentIdAsync(request.StudentId);
        return _mapper.Map<IEnumerable<GetQuestionsDto>>(questionsFromDataBase);
    }
}