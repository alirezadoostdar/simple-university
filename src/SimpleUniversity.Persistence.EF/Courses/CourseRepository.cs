using SimpleUniversity.Application.Courses.Contracts;
using SimpleUniversity.Application.Teachers.Contracts;
using SimpleUniversity.Domain;
using SimpleUniversity.Domain.Courses.Dtos;
using System.Diagnostics.CodeAnalysis;

namespace SimpleUniversity.Persistence.EF.Courses;

public class CourseRepository : ICourseRepository
{
    private readonly EFDbContext _context;

    public CourseRepository(EFDbContext context)
    {
        _context = context;
    }

    public void Add(Course course)
    {
        _context.Courses.Add(course);
    }

    public void Delete(Course course)
    {
        _context.Courses.Remove(course);
    }

    public List<Course> GetAll()
    {
        return _context.Courses.ToList();
    }

    public Course? GetById(int id)
    {
        return _context.Courses.Find(id);
    }

    public List<GetCourseTermsDto> GetTerms(int courseId)
    {
        var list = _context.Classes
            .Where(_ => _.CourseId == courseId)
            .Select(_ => new GetCourseTermsDto
            {
                Id = _.TermId,
                Title = _.Term.Title
            }).ToList();
        return list;
    }

    public List<GetTeacherDto> GetTeachers(int courseId)
    {
        var list = _context.Classes.Where(_ => _.CourseId == courseId)
            .Select(_ => new GetTeacherDto
            {
                Code = _.Id.ToString(),
                Id = _.TeacherId,
                FirstName = _.Teacher.FirstName,
                LastName = _.Teacher.LastName,
                
            }).ToList().Distinct(new GetTeacherDtoEqualityComparer()).ToList();
         
        return list;
    }

    public void Update(Course course)
    {
        _context.Courses.Update(course);
    }
}

public class GetTeacherDtoEqualityComparer : IEqualityComparer<GetTeacherDto>
{
    public bool Equals(GetTeacherDto? x, GetTeacherDto? y)
    {
        return x == y;
    }

    public int GetHashCode([DisallowNull] GetTeacherDto obj)
    {
        return obj.FirstName.GetHashCode();
    }
}
