using AutoMapper;
using MediatR;
using Univali.Api.Features.Common;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Answers.Queries.GetAnswersDetail;

public class GetAnswersDetailQueryHandler : IRequestHandler<GetAnswersDetailQuery, GetAnswersDetailResponse>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public GetAnswersDetailQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<GetAnswersDetailResponse> Handle(GetAnswersDetailQuery request, CancellationToken cancellationToken)
    {
        GetAnswersDetailResponse getAnswersDetailResponse = new();

        var questionFromDatabase = await _publisherRepository.GetQuestionWithAnswersByIdAsync(request.QuestionId);

        if(questionFromDatabase == null)
        {
            getAnswersDetailResponse.Errors.Add("Question", new string[] {"Question Not Found"});
            getAnswersDetailResponse.ErrorType = Error.NotFoundProblem;
            return getAnswersDetailResponse;
        }

        var (answersFromDatabase, paginationMetadata) = await _publisherRepository.GetAnswersAsync(questionFromDatabase.QuestionId, request.PageNumber, request.PageSize);

        getAnswersDetailResponse.AnswersDetailDtos =  _mapper.Map<IEnumerable<GetAnswersDetailDto>>(answersFromDatabase);

        getAnswersDetailResponse.paginationMetadata = paginationMetadata;

        return getAnswersDetailResponse;
    }
}