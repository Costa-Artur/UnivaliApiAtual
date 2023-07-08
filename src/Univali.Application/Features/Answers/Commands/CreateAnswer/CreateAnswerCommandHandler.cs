using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;
using Univali.Api.Features.Common;

namespace Univali.Api.Features.Answers.Commands.CreateAnswer;

public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand, CreateAnswerCommandResponse>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateAnswerCommand> _validator;

    public CreateAnswerCommandHandler(IPublisherRepository repository, IMapper mapper, IValidator<CreateAnswerCommand> validator)
    {
        _repository = repository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CreateAnswerCommandResponse> Handle(CreateAnswerCommand request, CancellationToken cancellationToken)
    {
        CreateAnswerCommandResponse createAnswerCommandResponse = new();

        ValidationResult validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            createAnswerCommandResponse.FillErrors(validationResult);
            createAnswerCommandResponse.ErrorType = Error.ValidationProblem;
            return createAnswerCommandResponse;
        }

        if (!await _repository.QuestionExistsAsync(request.QuestionId))
        {
            createAnswerCommandResponse.ErrorType = Error.NotFoundProblem;
            createAnswerCommandResponse.Errors.Add("Question",new string[] {"Question Not Found"});
            return createAnswerCommandResponse;
        }

        if (!await _repository.AuthorExistsAsync(request.AuthorId))
        {
            createAnswerCommandResponse.ErrorType = Error.NotFoundProblem;
            createAnswerCommandResponse.Errors.Add("Author",new string[] {"Author Not Found"});
            return createAnswerCommandResponse;
        }

        var answerEntity = _mapper.Map<Answer>(request);

        _repository.AddAnswer(answerEntity);
        await _repository.SaveChangesAsync();

        createAnswerCommandResponse.Answer = _mapper.Map<CreateAnswerDto>(answerEntity);
        return createAnswerCommandResponse;
    }
}