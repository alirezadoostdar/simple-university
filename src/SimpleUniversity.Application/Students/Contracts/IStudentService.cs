
using SimpleUniversity.Application.Students.Contracts;
using SimpleUniversity.Domain.Students.Dtos;

namespace SimpleUniversity.Application.Students.Contracts
{
    public interface IStudentService
    {
        int Create(CreateStudentDto dto);
        List<GetStudentDto> GetAll();
        List<GetStudentUnitTermsDto> GetListTotalUnits();
        List<GetStudentUnitTermsDto> GetListWithTotalUnitByTerm(int termId);
    }
}
