using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Students.Queries.GetStudentDetails;

public class GetStudentDetailQueryHandler : IRequestHandler<GetStudentDetailsQuery, GetStudentDetailsResponse>
{
    private readonly IPublisherRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentDetailQueryHandler(IPublisherRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<GetStudentDetailsResponse> Handle(GetStudentDetailsQuery request, CancellationToken cancellationToken)
    {
        GetStudentDetailsResponse getStudentsDetailsResponse = new();

        Student? studentFromRepository = await _studentRepository.GetStudentByIdAsync(request.Id);
        getStudentsDetailsResponse.Student = _mapper.Map<GetStudentDetailsDto>(studentFromRepository);
        return getStudentsDetailsResponse;
    }
}