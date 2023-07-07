using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Publishers.Commands.DeletePublisher;

public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, bool>
{
    private readonly IPublisherRepository _publisherRepository;

    public DeletePublisherCommandHandler(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<bool> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisherEntity = await _publisherRepository.GetPublisherByIdAsync(request.PublisherId);

        if(publisherEntity == null) return false;

        _publisherRepository.RemovePublisher(publisherEntity);
        return await _publisherRepository.SaveChangesAsync();
    }
}