using Microsoft.EntityFrameworkCore;
using SimpleUniversity.Application.Teachers.Contracts;
using SimpleUniversity.Domain;

namespace SimpleUniversity.Persistence.EF.Teachers;

public class TeacherRepository : ITeacherRepository
{
    private readonly EFDbContext _context;

    public TeacherRepository(EFDbContext context)
    {
        _context = context;
    }

    public void Add(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public void Delete(Teacher teacher)
    {
        throw new NotImplementedException();
    }

    public List<GetTeacherDto> GetAll()
    {
        throw new NotImplementedException();
    }

    public int GetTotalUnitByTerm(int id, int termId)
    {
        var totalUnit = _context.Classes.Where(_ => _.TeacherId == id && _.TermId == termId)
         .Sum(_ => _.Course.Unit);
        var x = _context.Set<Teacher>().Where(_ => _.Id == id)
            .Select(_ => new
            {
                name = _.LastName,
                count = _.Classes.Where(c => c.TermId == termId)
                .Sum(x => x.Course.Unit)
            }).FirstOrDefault();

        return totalUnit;
    } 

    public void Update(Teacher teacher)
    {
        throw new NotImplementedException();
    }
}
