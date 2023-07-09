using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Features.Answers.Queries.GetAnswerDetail;
using Univali.Api.Features.AnswersCollection.GetAnswersDetail;
using Univali.Api.Repositories;

namespace Univali.Api.Controllers;

[Route("api/answers-collection")]
[Authorize]
public class AnswersCollectionController : MainController
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMediator _mediator;
    
    public AnswersCollectionController(IPublisherRepository publisherRepository, IMediator mediator){
        _publisherRepository = publisherRepository;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAnswerDetailDto>>> GetAnswers(int authorId, string searchQuery = "", int pageNumber = 1, int pageSize = 5)
    {
        if(pageSize > maxPageSize) pageSize = maxPageSize;

        var getAnswersCollectionDetailQuery = new GetAnswersCollectionDetailQuery{AuthorId = authorId, SearchQuery = searchQuery, PageNumber = pageNumber, PageSize = pageSize};

        var answersResponse = await _mediator.Send(getAnswersCollectionDetailQuery);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(answersResponse.PaginationMetadata));

        return Ok(answersResponse.AnswersDetailDtos);
    }
}