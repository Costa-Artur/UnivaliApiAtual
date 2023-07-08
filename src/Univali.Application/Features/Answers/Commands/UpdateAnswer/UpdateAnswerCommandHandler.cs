using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Univali.Api.Features.Common;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Answers.Commands.UpdateAnswer;

public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand, UpdateAnswerCommandResponse>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateAnswerCommand> _validator;

    public UpdateAnswerCommandHandler(IPublisherRepository repository, IMapper mapper, IValidator<UpdateAnswerCommand> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<UpdateAnswerCommandResponse> Handle(UpdateAnswerCommand request, CancellationToken cancellationToken)
    {
        UpdateAnswerCommandResponse updateAnswerCommandResponse = new();

        ValidationResult validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            updateAnswerCommandResponse.FillErrors(validationResult);
            updateAnswerCommandResponse.ErrorType = Error.ValidationProblem;
            return updateAnswerCommandResponse;
        }

        if (!await _repository.AuthorExistsAsync(request.AuthorId))
        {
            updateAnswerCommandResponse.ErrorType = Error.NotFoundProblem;
            updateAnswerCommandResponse.Errors.Add("Author",new string[] {"Author Not Found"});
            return updateAnswerCommandResponse;
        }


        var questionEntity = await _repository.GetQuestionWithAnswersByIdAsync(request.QuestionId);

        if (questionEntity == null)
        {
            updateAnswerCommandResponse.Errors.Add("Question", new string[]{"Question Not Found"});
            updateAnswerCommandResponse.ErrorType = Error.NotFoundProblem;
            return updateAnswerCommandResponse;
        }

        var answerEntity = questionEntity.Answers.FirstOrDefault(a => a.AnswerId == request.AnswerId);

        if (answerEntity == null) 
        {
            updateAnswerCommandResponse.Errors.Add("Answer", new string[]{"Answer not found in this question"});
            updateAnswerCommandResponse.ErrorType = Error.NotFoundProblem;
            return updateAnswerCommandResponse;
        }    

        _mapper.Map(request, answerEntity);
        
        await _repository.SaveChangesAsync();

        return updateAnswerCommandResponse;
    }
}