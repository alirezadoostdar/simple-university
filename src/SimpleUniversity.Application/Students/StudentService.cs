using SimpleUniversity.Application.Contracts;
using SimpleUniversity.Application.Students.Contracts;
using SimpleUniversity.Domain;
using SimpleUniversity.Domain.Students.Dtos;

namespace SimpleUniversity.Application.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        private readonly IUnitOfWork _unitOfWork;
        public StudentService(
                            IStudentRepository repository,
                            IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public int Create(CreateStudentDto dto)
        {
            var student = new Student
            {
                BirthDate = dto.BirthDate,
                Code = dto.Code,
                FatherName = dto.FatherName,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Gender = dto.Gender,
                NationalCode = dto.NationalCode,
                ContactInfo = new ContactInfo
                {
                    Address = dto.Address,
                    Phone = dto.Phone,
                }
            };

            _repository.Add(student);
            _unitOfWork.SaveChanges();

            return student.Id;
        }

        public List<GetStudentDto> GetAll()
        {
            return _repository.GetAll();
        }

        public List<GetStudentUnitTermsDto> GetListWithTotalUnitByTerm(int termId)
        {
            return _repository.GetListWithTotalUnitByTerm(termId);
           
        }

    }
}
