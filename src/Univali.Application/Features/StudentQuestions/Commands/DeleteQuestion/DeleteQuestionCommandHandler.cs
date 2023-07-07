using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Questions.Commands.DeleteQuestion;

public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
{
    private readonly IPublisherRepository _questionRepository;

    public DeleteQuestionCommandHandler(IPublisherRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {
        if(! await _questionRepository.LessonExistsAsync(request.StudentId))
        {
            return false;
        }

        var questionEntity = await _questionRepository.GetQuestionByIdAsync(request.QuestionId);

        if(questionEntity == null) return false;
        
        if(questionEntity.StudentId != request.StudentId) return false;
        
        _questionRepository.DeleteQuestion(questionEntity);
        
        return await _questionRepository.SaveChangesAsync();
    }
}