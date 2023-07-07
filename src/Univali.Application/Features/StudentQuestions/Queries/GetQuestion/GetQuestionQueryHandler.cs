using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Queries.GetQuestion;

public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, GetQuestionDto>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionQueryHandler(IMapper mapper, IPublisherRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<GetQuestionDto> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.StudentExistsAsync(request.StudentId))
        {
            return null!;
        }

        var questionFromDataBase = await _questionRepository.GetQuestionByIdAsync(request.QuestionId);
        return _mapper.Map<GetQuestionDto>(questionFromDataBase);
    }
}