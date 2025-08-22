using Microsoft.AspNetCore.Mvc;
using SimpleUniversity.Application.Terms.Contracts;

namespace SimpleUniversity.EndPoint.Api.Controllers
{
    [ApiController]
    [Route("api/terms")]
    public class TermsController : Controller
    {
        private readonly ITermsService _service;

        public TermsController(ITermsService service)
        {
            _service = service;
        }

        [HttpGet]
        public List<GetTermDto> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("{id:int}")]
        public GetTermDto Get(int id)
        {
           return _service.GetById(id);
        }

        [HttpPost]
        public int Create(AddTermDto dto)
        {
            return _service.Add(dto);
        }

        [HttpPut("{id:int})")]
        public void Update(int id, UpdateTermDto dto)
        {
            _service.Update(id, dto);
        }

        [HttpDelete("{id:int}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}
