using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Features.Common;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Answers.Commands.DeleteAnswer;

public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, DeleteAnswerCommandResponse>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public DeleteAnswerCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<DeleteAnswerCommandResponse> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
    {
        DeleteAnswerCommandResponse deleteAnswerCommandResponse = new ();

        var questionEntity = await _repository.GetQuestionWithAnswersByIdAsync(request.QuestionId);

        if (questionEntity == null){
            deleteAnswerCommandResponse.Errors.Add("Question", new string[] {"Question Not Found"});
            deleteAnswerCommandResponse.ErrorType = Error.NotFoundProblem;
            return deleteAnswerCommandResponse;
        }

        var answerEntity = questionEntity.Answers.FirstOrDefault(a => a.AnswerId == request.AnswerId);

        if (answerEntity == null){
            deleteAnswerCommandResponse.Errors.Add("Answer", new string[] {"Answer not found in this question"});
            deleteAnswerCommandResponse.ErrorType = Error.NotFoundProblem;
            return deleteAnswerCommandResponse;
        }

        _repository.DeleteAnswer(answerEntity);
        await _repository.SaveChangesAsync();
        return deleteAnswerCommandResponse;
    }
}