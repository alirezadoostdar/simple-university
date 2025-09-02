using SimpleUniversity.Application.Teachers.Contracts;
using SimpleUniversity.Domain;
using SimpleUniversity.Domain.Courses.Dtos;

namespace SimpleUniversity.Application.Courses.Contracts;

public interface ICourseRepository
{
    void Add(Course course);
    void Update(Course course);
    void Delete(Course course);
    Course? GetById(int id);
    List<Course> GetAll();
    List<GetCourseTermsDto> GetTerms(int courseId);
    List<GetTeacherDto> GetTeachers(int courseId);
}
