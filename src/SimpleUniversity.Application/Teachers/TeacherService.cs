using SimpleUniversity.Application.Contracts;
using SimpleUniversity.Application.Teachers.Contracts;

namespace SimpleUniversity.Application.Teachers;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public TeacherService(ITeacherRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public int Create(AddTeacherDto dto)
    {
        throw new NotImplementedException();
    }

    public List<GetTeacherDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public int GetTotalUnitByTerm(int id, int termId)
    {
        throw new NotImplementedException();
    }
}
