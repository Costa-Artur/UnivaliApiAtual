using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Controllers;

[Route("api/answers-collection")]
[Authorize]
public class AnswersCollectionController : MainController
{
    private readonly IPublisherRepository _publisherRepository;
    
    public AnswersCollectionController(IPublisherRepository publisherRepository){
        _publisherRepository = publisherRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Answer>>> GetAnswers(int authorId, string? searchQuery = "", int pageNumber = 1, int pageSize = 5)
    {
        if(pageSize > maxPageSize) pageSize = maxPageSize;

        var (answers, paginationMetadata) = await _publisherRepository.GetAnswersAsync(authorId, searchQuery, pageNumber, pageSize);

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

        return Ok(answers);
    }
}