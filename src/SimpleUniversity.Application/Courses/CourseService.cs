using SimpleUniversity.Application.Contracts;
using SimpleUniversity.Application.Courses.Contracts;
using SimpleUniversity.Application.Courses.Contracts.Exceptions;
using SimpleUniversity.Domain;
using SimpleUniversity.Domain.Courses.Dtos;

namespace SimpleUniversity.Application.Courses;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(ICourseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public int Add(AddCourseDto dto)
    {
        var course = new Course
        {
            Title = dto.Title,
            Unit = dto.Unit,
        };

        _repository.Add(course);
        _unitOfWork.SaveChanges();
        return course.Id;
    }

    public void Delete(int id)
    {
        var course = _repository.GetById(id);
        if (course is null)
            throw new CourseNotFoundException();

        _repository.Delete(course);
        _unitOfWork.SaveChanges();
    }

    public List<GetCourseDto> GetAll()
    {
        var list = _repository.GetAll()
            .Select(x => new GetCourseDto
            {
                Id = x.Id,
                Title = x.Title,
                Unit = x.Unit,
            }).ToList();

        return list;
    }

    public GetCourseDto GetById(int id)
    {
        var course = _repository.GetById(id);
        if (course is null)
            throw new CourseNotFoundException();

        return new GetCourseDto
        {
            Id = id,
            Title = course.Title,
            Unit = course.Unit,
        };
    }

    public List<GetCourseTermsDto> GetTerms(int courseId)
    {
        return _repository.GetTerms(courseId);
    }

    public void Update(int id, UpdateCourseDto dto)
    {
        var course = _repository.GetById(id);
        if (course is null)
            throw new CourseNotFoundException();

        course.Title = dto.Title;
        course.Unit = dto.Unit;

        _repository.Update(course);
        _unitOfWork.SaveChanges();
    }
}
