using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Features.QuestionsCollection.Queries.GetQuestionsCollection;
using Univali.Api.Repositories;

namespace Univali.Api.Controllers;

[Route("api/students/{studentId}/questions-collection")]
[Authorize]
public class QuestionsCollectionController : MainController
{
    private readonly IMediator _mediator;

    public QuestionsCollectionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetQuestions(int studentId, string? category = "", string? searchQuery = "")
    {
        Console.WriteLine("entrou");
        var getQuestionsCollectionQuery = new GetQuestionsCollectionQuery { StudentId = studentId, Category = category, SearchQuery = searchQuery };

        var questionToReturn = await _mediator.Send(getQuestionsCollectionQuery);

        return Ok(questionToReturn);
    }
}