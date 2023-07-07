using AutoMapper;
using Univali.Api.Entities;
using Univali.Api.Repositories;
using MediatR;
using FluentValidation;


namespace Univali.Api.Features.Lessons.Commands.CreateLesson;

public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, CreateLessonCommandResponse>{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateLessonCommand> _validator;

    public CreateLessonCommandHandler(IPublisherRepository publisherRepository, IMapper mapper, IValidator<CreateLessonCommand> validator)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CreateLessonCommandResponse> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
    {
        var createLessonCommandResponse = new CreateLessonCommandResponse();

        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            createLessonCommandResponse.FillErrors(validationResult);
            return createLessonCommandResponse;
        }

        if (!await _publisherRepository.ModuleExistsAsync(request.ModuleId))
        {
            return createLessonCommandResponse;
        }

        var lessonEntity = _mapper.Map<Lesson>(request);
        _publisherRepository.CreateLesson(lessonEntity);
        await _publisherRepository.SaveChangesAsync();
        createLessonCommandResponse.Lesson = _mapper.Map<CreateLessonCommandDto>(lessonEntity);
        return createLessonCommandResponse;
    }
}
