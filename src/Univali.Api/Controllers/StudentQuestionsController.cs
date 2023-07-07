using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Questions.Commands.DeleteQuestion;
using Univali.Api.Features.Questions.Commands.CreateQuestion;
using Univali.Api.Features.Questions.Commands.UpdateQuestion;
using Univali.Api.Features.Questions.Queries.GetQuestion;
using Univali.Api.Features.Questions.Queries.GetQuestions;
using Univali.Api.Features.Questions.Queries.GetQuestionWithAnswers;

namespace Univali.Api.Controllers;

[Route("api/students/{studentId}/questions")]
[Authorize]
public class StudentQuestionsController : MainController
{
    private readonly IMediator _mediator;

    public StudentQuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetQuestionsDto>>> GetQuestions(
        int studentId
    )
    {
        var questionToReturn = await _mediator.Send(new GetQuestionsQuery { StudentId = studentId });

        if(questionToReturn == null) return NotFound(ModelState);

        return Ok(questionToReturn);
    }

    // [HttpGet("{questionId}", Name = "GetQuestionById")]
    // public async Task<ActionResult<GetQuestionDto>> GetQuestionById(
    //     int studentId, 
    //     int questionId
    // )
    // {
    //     var questionToReturn = await _mediator.Send(new GetQuestionQuery { QuestionId = questionId, StudentId = studentId });

    //     if(questionToReturn == null) return NotFound();

    //     return Ok(questionToReturn);
    // }

    [HttpGet("{questionId}", Name = "GetQuestionById")]
    public async Task<ActionResult<GetQuestionWithAnswersDto>> GetQuestionById(
        int studentId, 
        int questionId
    )
    {
        var questionToReturn = await _mediator.Send(new GetQuestionWithAnswersQuery { QuestionId = questionId, StudentId = studentId });

        if(questionToReturn == null) return NotFound(ModelState);

        return Ok(questionToReturn);
    }

    [HttpPost]
    public async Task<ActionResult<CreateQuestionDto>> CreateQuestion(
        int studentId,
        CreateQuestionCommand createQuestionCommand
    )
    {
        createQuestionCommand.StudentId = studentId;
        createQuestionCommand.CreationDate = DateTime.UtcNow;

        var createQuestionCommandResponse = await _mediator.Send(createQuestionCommand);

        if(!createQuestionCommandResponse.IsSuccess)
        {
            ConfigureModelState(createQuestionCommandResponse.Errors);
            return ValidationProblem(ModelState);
        }

        if(createQuestionCommandResponse.Question == null) return NotFound(ModelState);

        return CreatedAtRoute
        (
            "GetQuestionById",
            new {studentId, createQuestionCommandResponse.Question.QuestionId},
            createQuestionCommandResponse.Question
        );
    }

    [HttpPut("{questionId}")]
    public async Task<ActionResult<UpdateQuestionCommandResponse>> UpdateQuestion(
        int studentId,
        int questionId,
        UpdateQuestionCommand updateQuestionCommand
    )
    {
        if (updateQuestionCommand.QuestionId != questionId) return BadRequest();

        updateQuestionCommand.StudentId = studentId;
        updateQuestionCommand.LastUpdate = DateTime.UtcNow;

        var updateQuestionCommandResponse = await _mediator.Send(updateQuestionCommand);

        if(!updateQuestionCommandResponse.IsSuccess)
        {
            ConfigureModelState(updateQuestionCommandResponse.Errors);
            return ValidationProblem(ModelState);
        }

        if(!updateQuestionCommandResponse.Exist) return NotFound(ModelState);

        return NoContent();
    }

    [HttpDelete("{questionId}")]
    public async Task<ActionResult> DeleteQuestion(int studentId, int questionId)
    {

        var deleteQuestionCommand = new DeleteQuestionCommand{ StudentId = studentId, QuestionId = questionId};

        if(!await _mediator.Send(deleteQuestionCommand)) return NotFound(ModelState);

        return NoContent();
    }
}