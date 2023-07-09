using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Features.Answers.Commands.CreateAnswer;
using Univali.Api.Features.Answers.Commands.DeleteAnswer;
using Univali.Api.Features.Answers.Commands.UpdateAnswer;
using Univali.Api.Features.Answers.Queries.GetAnswerDetail;
using Univali.Api.Features.Answers.Queries.GetAnswersDetail;
using Univali.Api.Features.Common;

namespace Univali.Api.Controllers;

[Route("api/questions/{questionId}/answers")]
[Authorize]
public class AnswersController : MainController
{
    private readonly IMediator _mediator;

    public AnswersController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetAnswersDetailDto>>> GetAnswers(int questionId, int pageNumber = 1, int pageSize = 5)
    {
        if(pageSize > maxPageSize) pageSize = maxPageSize;

        var getAnswersDetailQuery = new GetAnswersDetailQuery {QuestionId = questionId, PageNumber = pageNumber, PageSize = pageSize};

        var answersResponse = await _mediator.Send(getAnswersDetailQuery);

        if(!answersResponse.IsSuccess)
        {
            return CheckStatusCode(answersResponse);
        }

        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(answersResponse.paginationMetadata));

        return Ok(answersResponse.AnswersDetailDtos);
    }

    [HttpGet("{answerId}", Name = "GetAnswerById")]
    public async Task<ActionResult<GetAnswerDetailDto>> GetAnswerById(int questionId, int answerId)
    {
        var getAnswerDetailQuery = new GetAnswerDetailQuery {QuestionId = questionId, AnswerId = answerId};

        var answerResponse = await _mediator.Send(getAnswerDetailQuery);

        if(!answerResponse.IsSuccess)
        {
            return CheckStatusCode(answerResponse);
        }

        return Ok(answerResponse.Answer);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAnswerDto>> CreateAnswer(int questionId, CreateAnswerCommand createAnswerCommand)
    {
        createAnswerCommand.QuestionId = questionId;

        var createAnswerCommandResponse = await _mediator.Send(createAnswerCommand);

        if (!createAnswerCommandResponse.IsSuccess)
        {
            return CheckStatusCode(createAnswerCommandResponse);
        }

        return CreatedAtRoute
        (
            "GetAnswerById",
            new {questionId, createAnswerCommandResponse.Answer.AnswerId},
            createAnswerCommandResponse.Answer
        );
    }

    [HttpPut("{answerId}")]
    public async Task<ActionResult> UpdateAnswer(int questionId, int answerId, UpdateAnswerCommand updateAnswerCommand)
    {
        if (updateAnswerCommand.AnswerId != answerId) return BadRequest();

        updateAnswerCommand.QuestionId = questionId;

        var updateAnswerCommandResponse = await _mediator.Send(updateAnswerCommand);

        if (!updateAnswerCommandResponse.IsSuccess)
        {
            return CheckStatusCode(updateAnswerCommandResponse);
        }

        return NoContent();
    }

    [HttpDelete("{answerId}")]
    public async Task<ActionResult> DeleteAnswer(int questionId, int answerId)
    {
        var deleteAnswerCommand = new DeleteAnswerCommand {AnswerId = answerId, QuestionId = questionId};

        var answerResponse = await _mediator.Send(deleteAnswerCommand);

        if (!answerResponse.IsSuccess)
        {
            return  CheckStatusCode(answerResponse);
        }

        return NoContent();
    }
}