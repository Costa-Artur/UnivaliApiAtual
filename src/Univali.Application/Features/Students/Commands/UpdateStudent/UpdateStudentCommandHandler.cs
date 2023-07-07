using AutoMapper;
using FluentValidation;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Students.Commands.UpdateStudent;

// O primeiro parâmetro é o tipo da mensagem
// O segundo parâmetro é o tipo que se espera receber.
public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdateStudentCommandResponse>
{
    private readonly IPublisherRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateStudentCommand> _validator;

    public UpdateStudentCommandHandler(IPublisherRepository studentRepository, IMapper mapper, IValidator<UpdateStudentCommand> validator)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
    {
        UpdateStudentCommandResponse updateStudentCommandResponse = new();

        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            updateStudentCommandResponse.FillErrors(validationResult);
            return updateStudentCommandResponse;
        }

        var studentFromDatabase = await _studentRepository.GetStudentByIdAsync(request.Id);

        if (studentFromDatabase == null)
        {
            updateStudentCommandResponse.Exist = false;
            return updateStudentCommandResponse;
        }

        _mapper.Map(request, studentFromDatabase);

        updateStudentCommandResponse.Exist = await _studentRepository.SaveChangesAsync();

        return updateStudentCommandResponse;
    }
}