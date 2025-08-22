using Microsoft.AspNetCore.Mvc;
using SimpleUniversity.Application.Teachers.Contracts;

namespace SimpleUniversity.EndPoint.Api.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeachersController(ITeacherService service)
    {
        _service = service;
    }

    [HttpGet("{teacherId:int}/terms/{termId:int}/GetTotalUnits")]
    public int GetTotalUnits(int teacherId, int termId)
    {
        return _service.GetTotalUnitByTerm(teacherId, termId);
    }
}
