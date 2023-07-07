using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.DbContexts;
using Univali.Api.Features.Students.Commands.CreateStudent;
using Univali.Api.Features.Students.Commands.DeleteStudent;
using Univali.Api.Features.Students.Commands.UpdateStudent;
using Univali.Api.Features.Students.Queries.GetStudentCollectionDetails;
using Univali.Api.Features.Students.Queries.GetStudentDetails;
using Univali.Api.Features.Students.Queries.GetStudentsDetails;
using Univali.Api.Models;
using Univali.Api.Repositories;


namespace Univali.Api.Controllers;

[Route("api/students")]
[Authorize]
public class StudentsController : MainController
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    ///////////////////////////////////////////////////////////////////////////
    // Read
    ///////////////////////////////////////////////////////////////////////////
    [HttpGet]
    public async Task<ActionResult<GetStudentsDetailsResponse>> GetStudentsAsync()
    {
        GetStudentsDetailsQuery getStudentsDetailsQuery = new();

        GetStudentsDetailsResponse getStudentsDetailsResponse = await _mediator.Send(getStudentsDetailsQuery);

        if (!getStudentsDetailsResponse.IsSuccess) return NotFound(ModelState);

        return Ok(getStudentsDetailsResponse.Students);
    }

    [HttpGet("{studentId}", Name = "GetStudentById")]
    public async Task<ActionResult<GetStudentDetailsResponse>> GetStudentByIdAsync(int studentId)
    {
        Console.WriteLine("Entrou");
        var getStudentDetailsQuery = new GetStudentDetailsQuery{Id = studentId};

        GetStudentDetailsResponse getStudentDetailsResponse = await _mediator.Send(getStudentDetailsQuery);

        if (getStudentDetailsResponse.Student == null) return NotFound(ModelState);

        return Ok(getStudentDetailsResponse.Student);
    }

    [HttpGet("collection")]
    //***
    public async Task<ActionResult<GetStudentCollectionDetailsResponse>> GetStudentCollectionAsync(string? name = "", string? cpf = "", string? searchQuery = "")
    {
        var getStudentCollectionDetailsQuery = new GetStudentCollectionDetailsQuery(name!, cpf!, searchQuery!);

        GetStudentCollectionDetailsResponse getStudentCollectionDetailsResponse = await _mediator.Send(getStudentCollectionDetailsQuery);

        if (!getStudentCollectionDetailsResponse.IsSuccess) return NotFound(ModelState);

        return Ok(getStudentCollectionDetailsResponse.StudentCollection);
    }

    ///////////////////////////////////////////////////////////////////////////
    // Create
    ///////////////////////////////////////////////////////////////////////////
    [HttpPost]
    public async Task<ActionResult<StudentDto>> CreateStudent(
        CreateStudentCommand createStudentCommand
        )
    {
        var createStudentCommandResponse = await _mediator.Send(createStudentCommand);

        if (!createStudentCommandResponse.IsSuccess)
        {
            ConfigureModelState(createStudentCommandResponse.Errors);
            return ValidationProblem(ModelState);
        }
        return CreatedAtRoute
        (
            "GetStudentById",
            new { studentId = createStudentCommandResponse.Student.StudentId },
            createStudentCommandResponse.Student
        );
    }


    ///////////////////////////////////////////////////////////////////////////
    // Update
    ///////////////////////////////////////////////////////////////////////////
    [HttpPut("{studentId}")]
    public async Task<ActionResult> UpdateStudent(int studentId,
        UpdateStudentCommand updateStudentCommand)
    {
        if (studentId != updateStudentCommand.Id) return BadRequest();

        var updateStudentCommandResponse = await _mediator.Send(updateStudentCommand);

        if (!updateStudentCommandResponse.IsSuccess)
        {
            ConfigureModelState(updateStudentCommandResponse.Errors);
            return ValidationProblem(ModelState);
        }

        if (!updateStudentCommandResponse.Exist) return NotFound(ModelState);

        return NoContent();
    }


    ///////////////////////////////////////////////////////////////////////////
    // Delete
    ///////////////////////////////////////////////////////////////////////////
    [HttpDelete("{studentId}")]
    public async Task<ActionResult> DeleteStudent(int studentId)
    {
        var deleteStudentCommand = new DeleteStudentCommand { Id = studentId };

        if (!await _mediator.Send(deleteStudentCommand)) return NotFound(ModelState);

        return NoContent();
    }

}