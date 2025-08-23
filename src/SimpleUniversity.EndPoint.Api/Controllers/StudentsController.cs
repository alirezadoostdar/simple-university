using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleUniversity.Application.Students.Contracts;
using SimpleUniversity.Domain.Students.Dtos;

namespace SimpleUniversity.EndPoint.Api.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }


        [HttpPost]
        public int Create(CreateStudentDto dto)
        {
            return _service.Create(dto);
        }

        [HttpGet]
        public List<GetStudentDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{termId:int}/GetListWithTotalUnitByTermId")]
        public List<GetStudentUnitTermsDto> GetStudentUnitTerms(int termId)
        {
            return _service.GetListWithTotalUnitByTerm(termId);
        }

        [HttpGet("{termId:int}/GetListTotalUnit")]
        public List<GetStudentUnitTermsDto> GetTotalUnit()
        {
            return _service.GetListTotalUnits();
        }
    }
}
