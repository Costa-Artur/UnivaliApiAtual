using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Features.Lessons.Commands.CreateLesson;
using Univali.Api.Features.Lessons.Commands.DeleteLesson;
using Univali.Api.Features.Lessons.Commands.UpdateLesson;
using Univali.Api.Features.Lessons.Queries.GetLessonDetail;
using Univali.Api.Features.Lessons.Queries.GetLessonsDetail;
using Univali.Api.Models;
using Univali.Api.Repositories;

namespace Univali.Api.Controllers;

[Route("api/lessons")]
[Authorize]
public class LessonsController : MainController
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public LessonsController(IPublisherRepository publisherRepository, IMediator mediator, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<GetLessonsDetailDto>>> GetLessonsAsync()
    {
        var lessonsToReturn = await _mediator.Send(new GetLessonsDetailQuery());

        return Ok(lessonsToReturn);
    }

    [HttpGet("{lessonId}", Name = "GetLessonByIdAsync")]
    public async Task<ActionResult<GetLessonDetailDto>> GetLessonByIdAsync(int lessonId)
    {
        var getLessonDetailQuery = new GetLessonDetailQuery() { LessonId = lessonId };

        var getLessonDetailResponse = await _mediator.Send(getLessonDetailQuery);

        if (getLessonDetailResponse.Lesson == null) return NotFound(ModelState);

        return Ok(getLessonDetailResponse.Lesson);
    }

    [HttpPost]
    public async Task<ActionResult<CreateLessonCommandDto>> CreateLesson([FromBody] LessonForCreationDto createLessonDto)
    {
        var createLessonCommand = _mapper.Map<CreateLessonCommand>(createLessonDto);

        var createLessonCommandResponse = await _mediator.Send(createLessonCommand);

        if (!createLessonCommandResponse.IsSuccess)
        {
            ConfigureModelState(createLessonCommandResponse.Errors);
            return ValidationProblem(ModelState);
        }

        if (createLessonCommandResponse.Lesson == null) return NotFound(ModelState);

        return CreatedAtRoute(
            "GetLessonByIdAsync",
            new { lessonId = createLessonCommandResponse.Lesson.LessonId },
            createLessonCommandResponse.Lesson
        );
    }

    [HttpPut("{lessonId}")]
    public async Task<ActionResult> UpdateLesson([FromBody] LessonForUpdateDto updateLessonDto, int lessonId)
    {
        if (updateLessonDto.LessonId != lessonId) return BadRequest();

        var updateLessonCommand = _mapper.Map<UpdateLessonCommand>(updateLessonDto);

        var updateLessonCommandResponse = await _mediator.Send(updateLessonCommand);

        if (!updateLessonCommandResponse.IsSuccess)
        {
            ConfigureModelState(updateLessonCommandResponse.Errors);
            return ValidationProblem(ModelState);
        }

        if (updateLessonCommandResponse.NotFound) return NotFound(ModelState);

        return NoContent();
    }

    [HttpDelete("{lessonId}")]
    public async Task<ActionResult> DeleteLesson(int lessonId)
    {
        var deleteLessonCommand = new DeleteLessonCommand() { LessonId = lessonId };

        if (!await _mediator.Send(deleteLessonCommand)) return NotFound(ModelState);

        return NoContent();
    }

}