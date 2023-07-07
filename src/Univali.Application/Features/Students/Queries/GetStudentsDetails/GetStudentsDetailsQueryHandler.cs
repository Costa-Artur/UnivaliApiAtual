using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Students.Queries.GetStudentsDetails;

public class GetStudentsDetailQueryHandler : IRequestHandler<GetStudentsDetailsQuery, GetStudentsDetailsResponse>
{
    private readonly IPublisherRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentsDetailQueryHandler(IPublisherRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<GetStudentsDetailsResponse> Handle(GetStudentsDetailsQuery request, CancellationToken cancellationToken)
    {
        GetStudentsDetailsResponse getStudentsDetailsResponse = new();

        IEnumerable<Student> studentsFromRepository = await _studentRepository.GetStudentsAsync();
        getStudentsDetailsResponse.Students = _mapper.Map<IEnumerable<GetStudentsDetailsDto>>(studentsFromRepository);
        //if(!getStudentsDetailsResponse.Students.Any()) getStudentsDetailsResponse.IsSuccess = false;
        return getStudentsDetailsResponse;
    }
}