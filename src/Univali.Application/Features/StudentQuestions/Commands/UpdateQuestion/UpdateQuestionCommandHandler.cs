using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Commands.UpdateQuestion;

public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, UpdateQuestionCommandResponse>
{
    private readonly IPublisherRepository _questionRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateQuestionCommand> _validator;

    public UpdateQuestionCommandHandler(IPublisherRepository questionRepository, IMapper mapper, IValidator<UpdateQuestionCommand> validator)
    {
        _questionRepository = questionRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<UpdateQuestionCommandResponse> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
    {
        UpdateQuestionCommandResponse updateQuestionCommandResponse = new();

        ValidationResult validationResult = _validator.Validate(request);

        if(!validationResult.IsValid)
        {
            updateQuestionCommandResponse.FillErrors(validationResult);
            return updateQuestionCommandResponse;
        }

        if(! await _questionRepository.StudentExistsAsync(request.StudentId))
        {
            updateQuestionCommandResponse.Exist = false;
            return updateQuestionCommandResponse;
        }

        var questionEntity = await _questionRepository.GetQuestionByIdAsync(request.QuestionId);

        if(questionEntity == null || questionEntity.StudentId != request.StudentId)
        {
            updateQuestionCommandResponse.Exist = false;
            return updateQuestionCommandResponse;
        }

        _mapper.Map(request, questionEntity);

        updateQuestionCommandResponse.Exist = await _questionRepository.SaveChangesAsync();

        return updateQuestionCommandResponse;
    }
}