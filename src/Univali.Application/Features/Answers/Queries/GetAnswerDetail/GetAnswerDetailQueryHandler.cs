using AutoMapper;
using MediatR;
using Univali.Api.Features.Common;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Answers.Queries.GetAnswerDetail;

public class GetAnswerDetailQueryHandler : IRequestHandler<GetAnswerDetailQuery, GetAnswerDetailResponse>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public GetAnswerDetailQueryHandler(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<GetAnswerDetailResponse> Handle(GetAnswerDetailQuery request, CancellationToken cancellationToken)
    {
        var getAnswerDetailResponse = new GetAnswerDetailResponse();

        var questionFromDatabase = await _publisherRepository.GetQuestionWithAnswersByIdAsync(request.QuestionId);

        if(questionFromDatabase == null)
        {
            getAnswerDetailResponse.ErrorType = Error.NotFoundProblem;
            getAnswerDetailResponse.Errors.Add("Question", new string[] {"Question Not Found"});
            return getAnswerDetailResponse;
        }

        var answerFromDatabase = questionFromDatabase.Answers.FirstOrDefault(a => a.AnswerId == request.AnswerId);

        if(answerFromDatabase == null)
        {
            getAnswerDetailResponse.ErrorType = Error.NotFoundProblem;
            getAnswerDetailResponse.Errors.Add("Answer", new string[] {"Answer not found in this question"});
            return getAnswerDetailResponse;
        }

        getAnswerDetailResponse.Answer =  _mapper.Map<GetAnswerDetailDto>(answerFromDatabase);

        return getAnswerDetailResponse;
    }
}