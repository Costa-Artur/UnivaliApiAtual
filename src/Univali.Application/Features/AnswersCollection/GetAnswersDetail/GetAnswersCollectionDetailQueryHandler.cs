using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.AnswersCollection.GetAnswersDetail;

public class GetAnswersCollectionDetailQueryHandler : IRequestHandler<GetAnswersCollectionDetailQuery, GetAnswersCollectionDetailResponse>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public GetAnswersCollectionDetailQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<GetAnswersCollectionDetailResponse> Handle(GetAnswersCollectionDetailQuery request, CancellationToken cancellationToken)
    {
        GetAnswersCollectionDetailResponse getAnswersCollectionDetailResponse = new();

        var (answersFromDatabase, paginationMetadata) = await _publisherRepository.GetAnswersAsync(request.AuthorId, request.SearchQuery, request.PageNumber, request.PageSize);

        getAnswersCollectionDetailResponse.PaginationMetadata = paginationMetadata;

        getAnswersCollectionDetailResponse.AnswersDetailDtos = _mapper.Map<IEnumerable<GetAnswersCollectionDetailDto>>(answersFromDatabase);

        return getAnswersCollectionDetailResponse;
    }
}