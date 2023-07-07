using MediatR;

namespace Univali.Api.Features.Students.Queries.GetStudentCollectionDetails;

public class GetStudentCollectionDetailsQuery : IRequest<GetStudentCollectionDetailsResponse> {
    public string? Name {get; set;}
    public string? CPF {get; set;}
    public string? SearchQuery {get; set;}


    public GetStudentCollectionDetailsQuery() {}
    public GetStudentCollectionDetailsQuery(string name, string cpf, string searchQuery) {
        Name = name;
        CPF = cpf;
        SearchQuery = searchQuery;
    }
}