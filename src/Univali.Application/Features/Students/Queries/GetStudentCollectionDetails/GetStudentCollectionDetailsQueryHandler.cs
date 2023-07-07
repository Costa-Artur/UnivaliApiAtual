using AutoMapper;
using MediatR;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Features.Students.Queries.GetStudentCollectionDetails;

public class GetStudentCollectionDetailQueryHandler : IRequestHandler<GetStudentCollectionDetailsQuery, GetStudentCollectionDetailsResponse>
{
    private readonly IPublisherRepository _studentRepository;
    private readonly IMapper _mapper;

    public GetStudentCollectionDetailQueryHandler(IPublisherRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<GetStudentCollectionDetailsResponse> Handle(GetStudentCollectionDetailsQuery request, CancellationToken cancellationToken)
    {
        GetStudentCollectionDetailsResponse getStudentCollectionDetailsResponse = new();

        IEnumerable<Student> studentsFromRepository = await _studentRepository.GetStudentCollectionAsync(request.Name, request.CPF, request.SearchQuery);
        getStudentCollectionDetailsResponse.StudentCollection = _mapper.Map<IEnumerable<GetStudentCollectionDetailsDto>>(studentsFromRepository);
        //if(!getStudentCollectionDetailsResponse.StudentCollection.Any()) getStudentCollectionDetailsResponse.IsSuccess = false;
        return getStudentCollectionDetailsResponse;
    }
}