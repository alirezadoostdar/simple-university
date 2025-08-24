using Microsoft.AspNetCore.Mvc;
using SimpleUniversity.Application.Courses.Contracts;
using SimpleUniversity.Application.Terms.Contracts;
using SimpleUniversity.Domain.Courses.Dtos;

namespace SimpleUniversity.EndPoint.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : Controller
{
    private readonly ICourseService _service;

    public CoursesController(ICourseService service)
    {
        _service = service;
    }

    [HttpGet]
    public List<GetCourseDto> GetAll()
    {
        return _service.GetAll();
    }

    [HttpGet("{id:int}")]
    public GetCourseDto Get(int id)
    {
        return _service.GetById(id);
    }

    [HttpPost]
    public int Create(AddCourseDto dto)
    {
        return _service.Add(dto);
    }

    [HttpPut("{id:int})")]
    public void Update(int id, UpdateCourseDto dto)
    {
        _service.Update(id, dto);
    }

    [HttpDelete("{id:int}")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }

    [HttpGet("{courseId:int}/ListOFTerms")]
    public List<GetCourseTermsDto> GetListOfTerms(int courseId)
    {
        return _service.GetTerms(courseId);
    }
}
