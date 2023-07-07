using AutoMapper;
using FluentValidation;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Students.Commands.CreateStudent;

// O primeiro parâmetro é o tipo da mensagem
// O segundo parâmetro é o tipo que se espera receber.
public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreateStudentCommandResponse>
{
    private readonly IPublisherRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateStudentCommand> _validator;

    public CreateStudentCommandHandler(IPublisherRepository studentRepository, IMapper mapper, IValidator<CreateStudentCommand> validator)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        CreateStudentCommandResponse createStudentCommandResponse = new();

        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            createStudentCommandResponse.FillErrors(validationResult);
            return createStudentCommandResponse;
        }

        var studentEntity = _mapper.Map<Student>(request);

        studentEntity.RegistrationDate = DateTime.UtcNow;

        _studentRepository.AddStudent(studentEntity);
        await _studentRepository.SaveChangesAsync();

        createStudentCommandResponse.Student = _mapper.Map<CreateStudentDto>(studentEntity);
        return createStudentCommandResponse;
    }
}