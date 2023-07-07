using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
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
            return updateAnswerCommandResponse;
        }

        if (!await _repository.QuestionExistsAsync(request.QuestionId)) return updateAnswerCommandResponse;

        var answerEntity = await _repository.GetAnswerByIdAsync(request.AnswerId);

        if (answerEntity == null) return updateAnswerCommandResponse;

        _mapper.Map(request, answerEntity);
        
        updateAnswerCommandResponse.Exists = await _repository.SaveChangesAsync();

        return updateAnswerCommandResponse;
    }
}