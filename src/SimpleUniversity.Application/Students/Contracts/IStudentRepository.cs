using SimpleUniversity.Domain;
using SimpleUniversity.Domain.Students.Dtos;

namespace SimpleUniversity.Application.Students.Contracts
{
    public interface IStudentRepository
    {
        void Add(Student student);
        List<GetStudentDto> GetAll();
        List<GetStudentUnitTermsDto> GetListTotalUnits();
        List<GetStudentUnitTermsDto> GetListWithTotalUnitByTerm(int termId);
    }
}
