using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Commands.CreateQuestion;

public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, CreateQuestionCommandResponse>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateQuestionCommand> _validator;

    public CreateQuestionCommandHandler(IPublisherRepository questionRepository, IMapper mapper, IValidator<CreateQuestionCommand> validator)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
    {
        CreateQuestionCommandResponse createQuestionCommandResponse = new();

        ValidationResult validationResult = _validator.Validate(request);

        if(!validationResult.IsValid)
        {
            createQuestionCommandResponse.FillErrors(validationResult);
            return createQuestionCommandResponse;
        }

        if(! await _questionRepository.StudentExistsAsync(request.StudentId))
        {
            return createQuestionCommandResponse;
        }

        var questionEntity = _mapper.Map<Question>(request);

        _questionRepository.AddQuestion(questionEntity);
        await _questionRepository.SaveChangesAsync();

        createQuestionCommandResponse.Question = _mapper.Map<CreateQuestionDto>(questionEntity);
        return createQuestionCommandResponse;
    }
}