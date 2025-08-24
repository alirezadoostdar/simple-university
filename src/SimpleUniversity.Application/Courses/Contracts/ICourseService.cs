using SimpleUniversity.Domain.Courses.Dtos;

namespace SimpleUniversity.Application.Courses.Contracts;

public interface ICourseService
{
    int Add(AddCourseDto dto);
    void Update(int id, UpdateCourseDto dto);
    void Delete(int id);
    GetCourseDto GetById(int id);
    List<GetCourseDto> GetAll();
    List<GetCourseTermsDto> GetTerms(int courseId);
}