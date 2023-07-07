using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Queries.GetQuestionWithAnswers;

public class GetQuestionWithAnswersQueryHandler : IRequestHandler<GetQuestionWithAnswersQuery, GetQuestionWithAnswersDto>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionWithAnswersQueryHandler(IMapper mapper, IPublisherRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<GetQuestionWithAnswersDto> Handle(GetQuestionWithAnswersQuery request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.StudentExistsAsync(request.StudentId))
        {
            return null!;
        }

        var questionFromDataBase = await _questionRepository.GetQuestionWithAnswersByIdAsync(request.QuestionId);
        return _mapper.Map<GetQuestionWithAnswersDto>(questionFromDataBase);
    }
}