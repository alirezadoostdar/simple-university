
using SimpleUniversity.Application.Students.Contracts;

namespace SimpleUniversity.Application.Students.Contracts
{
    public interface IStudentService
    {
        int Create(CreateStudentDto dto);
        List<GetStudentDto> GetAll();
    }
}
