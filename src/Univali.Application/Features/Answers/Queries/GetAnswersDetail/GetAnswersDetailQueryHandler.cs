using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Answers.Queries.GetAnswersDetail;

public class GetAnswersDetailQueryHandler : IRequestHandler<GetAnswersDetailQuery, IEnumerable<GetAnswersDetailDto>>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public GetAnswersDetailQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAnswersDetailDto>> Handle(GetAnswersDetailQuery request, CancellationToken cancellationToken)
    {
        if(! await _publisherRepository.QuestionExistsAsync(request.QuestionId))
        {
            return null!;
        }

        var answersFromDatabase = await _publisherRepository.GetAnswersAsync(request.QuestionId);
        return _mapper.Map<IEnumerable<GetAnswersDetailDto>>(answersFromDatabase);
    }
}