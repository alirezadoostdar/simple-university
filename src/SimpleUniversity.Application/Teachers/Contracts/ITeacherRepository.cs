
using SimpleUniversity.Application.Students.Contracts;
using SimpleUniversity.Application.Teachers.Contracts;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Application.Teachers.Contracts;

public interface ITeacherRepository
{
    void Add(Teacher teacher);
    void Update(Teacher teacher);
    void Delete(Teacher teacher);

    List<GetTeacherDto> GetAll();
    int GetTotalUnitByTerm(int id, int termId);
}
