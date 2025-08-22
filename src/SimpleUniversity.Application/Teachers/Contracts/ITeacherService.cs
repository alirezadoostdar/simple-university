namespace SimpleUniversity.Application.Teachers.Contracts;

public interface ITeacherService
{
    int Create(AddTeacherDto dto);
    List<GetTeacherDto> GetAll();
    int GetTotalUnitByTerm(int id, int termId);
}