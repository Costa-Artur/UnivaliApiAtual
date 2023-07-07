using AutoMapper;
using MediatR;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Students.Commands.DeleteStudent;

// O primeiro parâmetro é o tipo da mensagem
// O segundo parâmetro é o tipo que se espera receber.
public class DeleteStudentCommandHandler: IRequestHandler<DeleteStudentCommand, bool>
{
    private readonly IPublisherRepository _studentRepository;
    private readonly IMapper _mapper;

    public DeleteStudentCommandHandler(IPublisherRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {
        var studentFromDataBase = await _studentRepository.GetStudentByIdAsync(request.Id);
        
        if(studentFromDataBase ==  null)
        {
            return false;
        }
        
        _studentRepository.RemoveStudent(studentFromDataBase);
        return await _studentRepository.SaveChangesAsync();
    }
}