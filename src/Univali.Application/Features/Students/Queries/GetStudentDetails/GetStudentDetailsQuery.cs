using MediatR;

namespace Univali.Api.Features.Students.Queries.GetStudentDetails;

public class GetStudentDetailsQuery : IRequest<GetStudentDetailsResponse> 
{
    public int Id {get; set;}
}