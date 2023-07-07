using MediatR;

namespace Univali.Api.Features.QuestionsCollection.Queries.GetQuestionsCollection;

public class GetQuestionsCollectionQuery : IRequest<IEnumerable<GetQuestionsCollectionDto>>
{
        public int StudentId { get; set; }
        public string? Category { get; set; } = string.Empty;
        public string? SearchQuery { get; set;} = string.Empty;
}