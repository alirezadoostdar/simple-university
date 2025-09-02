using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleUniversity.Application.Courses.Contracts;
using SimpleUniversity.Application.Teachers.Contracts;
using SimpleUniversity.Application.Terms.Contracts;
using SimpleUniversity.Domain.Courses.Dtos;

namespace SimpleUniversity.EndPoint.Api.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : Controller
{
    private readonly ICourseService _service;
    private readonly ICourseRepository _courseRepository;

    public CoursesController(ICourseService service, ICourseRepository courseRepository)
    {
        _service = service;
        _courseRepository = courseRepository;
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

    [HttpGet("{courseId:int}/list-of-teachers")]
    public List<GetTeacherDto> GetListOfTeacher(int courseId)
    {
        return _courseRepository.GetTeachers(courseId);
    }
}
