using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Answers.Commands.DeleteAnswer;

public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand, bool>
{
    private readonly IPublisherRepository _repository;
    private readonly IMapper _mapper;

    public DeleteAnswerCommandHandler(IPublisherRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteAnswerCommand request, CancellationToken cancellationToken)
    {
        if (!await _repository.QuestionExistsAsync(request.QuestionId)) return false;

        var answerEntity = await _repository.GetAnswerByIdAsync(request.AnswerId);

        if (answerEntity == null) return false;

        _repository.DeleteAnswer(answerEntity);
        return await _repository.SaveChangesAsync();
    }
}