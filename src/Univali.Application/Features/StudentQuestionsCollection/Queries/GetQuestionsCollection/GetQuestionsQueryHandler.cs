using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.QuestionsCollection.Queries.GetQuestionsCollection;

public class GetQuestionsCollectionQueryHandler : IRequestHandler<GetQuestionsCollectionQuery, IEnumerable<GetQuestionsCollectionDto>>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;

    public GetQuestionsCollectionQueryHandler(IMapper mapper, IPublisherRepository questionRepository)
    {
        _mapper = mapper;
        _questionRepository = questionRepository;
    }

    public async Task<IEnumerable<GetQuestionsCollectionDto>> Handle(GetQuestionsCollectionQuery request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.StudentExistsAsync(request.StudentId) 
        )
        {
            return null!;
        }

        var questionsFromDataBase = await _questionRepository.GetQuestionsAsync(request.StudentId, request.Category, request.SearchQuery);
        return _mapper.Map<IEnumerable<GetQuestionsCollectionDto>>(questionsFromDataBase);
    }
}