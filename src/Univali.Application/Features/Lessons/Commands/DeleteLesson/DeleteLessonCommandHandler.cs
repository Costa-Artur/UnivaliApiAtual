using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Lessons.Commands.DeleteLesson;

public class DeleteLessonCommandHandler : IRequestHandler<DeleteLessonCommand, bool>
{
    private readonly IPublisherRepository _publisherRepository;

    public DeleteLessonCommandHandler(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<bool> Handle(DeleteLessonCommand request, CancellationToken cancellationToken)
    {
        var lessonFromDatabase = await _publisherRepository.GetLessonByIdAsync(request.LessonId);

        if (lessonFromDatabase == null)
        {
            return false;
        }

        _publisherRepository.DeleteLesson(lessonFromDatabase);

        return await _publisherRepository.SaveChangesAsync();
    }
}