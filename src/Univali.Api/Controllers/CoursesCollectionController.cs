using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;
using Univali.Api.Repositories;

namespace Univali.Api.Controllers;


[Route("api/courses-collection")]
[Authorize]
public class CoursesCollectionController : MainController
{
    private readonly IPublisherRepository _publisherRepository;
    
    public CoursesCollectionController(IPublisherRepository publisherRepository){
        _publisherRepository = publisherRepository;
    }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Course>>> GetCourses(string? category = "", string? searchQuery = "", int pageNumber = 1, int pageSize = 5)
    // {
    //     if(pageSize > maxPageSize) pageSize = maxPageSize;

    //     var (courses, paginationMetadata) = await _publisherRepository.GetCoursesAsync(category, searchQuery, pageNumber, pageSize);

    //     Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationMetadata));

    //     return Ok(courses);
    // }
}