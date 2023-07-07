using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Questions.Commands.DeleteQuestion;
using Univali.Api.Features.Questions.Commands.CreateQuestion;
using Univali.Api.Features.Questions.Commands.UpdateQuestion;
using Univali.Api.Features.Questions.Queries.GetLessonQuestion;
using Univali.Api.Features.Questions.Queries.GetLessonQuestions;
using Univali.Api.Features.Questions.Queries.GetLessonQuestionWithAnswers;

namespace Univali.Api.Controllers;

[Route("api/lessons/{lessonId}/questions")]
[Authorize]
public class LessonQuestionsController : MainController
{
    private readonly IMediator _mediator;

    public LessonQuestionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLessonQuestionsDto>>> GetLessonQuestions(
        int lessonId
    )
    {
        var questionToReturn = await _mediator.Send(new GetLessonQuestionsQuery { LessonId = lessonId });

        if(questionToReturn == null) return NotFound(ModelState);

        return Ok(questionToReturn);
    }

    [HttpGet("{questionId}", Name = "GetLessonQuestionById")]
    public async Task<ActionResult<GetLessonQuestionDto>> GetLessonQuestionById(
        int lessonId, 
        int questionId
    )
    {
        var questionToReturn = await _mediator.Send(new GetLessonQuestionQuery { QuestionId = questionId, LessonId = lessonId });

        if(questionToReturn == null) return NotFound(ModelState);

        return Ok(questionToReturn);
    }

    [HttpGet("{questionId}/with-answers", Name = "GetLessonQuestionWithAnswersById")]
    public async Task<ActionResult<GetLessonQuestionWithAnswersDto>> GetLessonQuestionWithAnswersById(
        int lessonId, 
        int questionId
    )
    {
        var questionToReturn = await _mediator.Send(new GetLessonQuestionWithAnswersQuery { QuestionId = questionId, LessonId = lessonId });

        if(questionToReturn == null) return NotFound(ModelState);

        return Ok(questionToReturn);
    }
}