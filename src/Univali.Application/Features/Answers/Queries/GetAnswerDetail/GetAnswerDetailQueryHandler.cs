using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Answers.Queries.GetAnswerDetail;

public class GetAnswerDetailQueryHandler : IRequestHandler<GetAnswerDetailQuery, GetAnswerDetailDto>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public GetAnswerDetailQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<GetAnswerDetailDto> Handle(GetAnswerDetailQuery request, CancellationToken cancellationToken)
    {
        if(! await _publisherRepository.QuestionExistsAsync(request.QuestionId))
        {
            return null!;
        }

        var answerFromDatabase = await _publisherRepository.GetAnswerByIdAsync(request.AnswerId);
        return _mapper.Map<GetAnswerDetailDto>(answerFromDatabase);
    }
}