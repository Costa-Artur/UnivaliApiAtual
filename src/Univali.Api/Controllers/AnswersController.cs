using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Features.Answers.Commands.CreateAnswer;
using Univali.Api.Features.Answers.Commands.DeleteAnswer;
using Univali.Api.Features.Answers.Commands.UpdateAnswer;
using Univali.Api.Features.Answers.Queries.GetAnswerDetail;
using Univali.Api.Features.Answers.Queries.GetAnswersDetail;

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
    public async Task<ActionResult<IEnumerable<GetAnswersDetailDto>>> GetAnswers(int questionId)
    {
        var getAnswersDetailQuery = new GetAnswersDetailQuery {QuestionId = questionId};

        var answersToReturn = await _mediator.Send(getAnswersDetailQuery);

        if (answersToReturn == null) return NotFound(ModelState);

        return Ok(answersToReturn);
    }

    [HttpGet("{answerId}", Name = "GetAnswerById")]
    public async Task<ActionResult<GetAnswerDetailDto>> GetAnswerById(int questionId, int answerId)
    {
        var getAnswerDetailQuery = new GetAnswerDetailQuery {QuestionId = questionId, AnswerId = answerId};

        var answerToReturn = await _mediator.Send(getAnswerDetailQuery);

        if (answerToReturn == null) return NotFound(ModelState);

        return Ok(answerToReturn);
    }

    [HttpPost]
    public async Task<ActionResult<CreateAnswerDto>> CreateAnswer(int questionId, CreateAnswerCommand createAnswerCommand)
    {
        var createAnswerCommandResponse = await _mediator.Send(createAnswerCommand);

        if (!createAnswerCommandResponse.IsSuccess)
        {
            ConfigureModelState(createAnswerCommandResponse.Errors);
            return UnprocessableEntity(ModelState);
        }

        if (createAnswerCommandResponse.Answer == null) return NotFound(ModelState);

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
            ConfigureModelState(updateAnswerCommandResponse.Errors);
            return UnprocessableEntity(ModelState);
        }

        if (!updateAnswerCommandResponse.Exists) return NotFound(ModelState);

        return NoContent();
    }

    [HttpDelete("{answerId}")]
    public async Task<ActionResult> DeleteAnswer(int questionId, int answerId)
    {
        var deleteAnswerCommand = new DeleteAnswerCommand {AnswerId = answerId, QuestionId = questionId};

        var result = await _mediator.Send(deleteAnswerCommand);

        if (!result) return NotFound(ModelState);

        return NoContent();
    }
}