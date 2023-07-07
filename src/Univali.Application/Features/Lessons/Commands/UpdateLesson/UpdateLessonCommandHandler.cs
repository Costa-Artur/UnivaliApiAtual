using AutoMapper;
using FluentValidation;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Lessons.Commands.UpdateLesson;

// O primeiro parâmetro é o tipo da mensagem
// O segundo parâmetro é o tipo que se espera receber.
public class UpdateLessonCommandHandler : IRequestHandler<UpdateLessonCommand, UpdateLessonCommandResponse>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateLessonCommand> _validator;

    public UpdateLessonCommandHandler(IPublisherRepository publisherRepository, IMapper mapper, IValidator<UpdateLessonCommand> validator)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<UpdateLessonCommandResponse> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
    {
        var updateLessonCommandResponse = new UpdateLessonCommandResponse();

        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            updateLessonCommandResponse.FillErrors(validationResult);
            return updateLessonCommandResponse;
        }

        if (!await _publisherRepository.ModuleExistsAsync(request.ModuleId))
        {
            updateLessonCommandResponse.NotFound = true;
            return updateLessonCommandResponse;
        }

        var lessonFromDatabase = await _publisherRepository.LessonExistsAsync(request.LessonId);

        if (!lessonFromDatabase)
        {
            updateLessonCommandResponse.NotFound = true;
            return updateLessonCommandResponse;
        }

        var lessonToUpdate = _mapper.Map<Lesson>(request);
        _publisherRepository.UpdateLesson(lessonToUpdate);

        await _publisherRepository.SaveChangesAsync();
        return updateLessonCommandResponse;
    }
}