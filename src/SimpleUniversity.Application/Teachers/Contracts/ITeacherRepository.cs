
using SimpleUniversity.Application.Teachers.Contracts;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Application.Teachers.Contracts;

public interface ITeacherRepository
{
    void Add(Teacher teacher);
    List<GetTeacherDto> GetAll();
}