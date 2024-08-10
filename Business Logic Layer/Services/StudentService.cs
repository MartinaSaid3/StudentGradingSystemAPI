using AutoMapper;
using Business_Logic_Layer.Dtos;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repo;
using Microsoft.Extensions.Configuration;

namespace Business_Logic_Layer.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepo studentRepo;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public StudentService(IStudentRepo _studentRepo,
            IMapper mapper,
            IConfiguration configuration)
        {
            studentRepo = _studentRepo;
            this.mapper = mapper;
            _configuration = configuration;
        }
        public async Task<List<StudentDto>> GetStudents()
        {
            List<Student> students = await studentRepo.GetStudents();
            List<StudentDto> studentsDto = mapper.Map<List<Student>, List<StudentDto>>(students);

            int maxGrade = _configuration.GetValue<int>("MaxGrade");

            foreach (var student in studentsDto)
            {
                var avgGrade = student.Grades.Any()
                    ? student.Grades.Average(g => (100.0 * g.Term1 / maxGrade + 100.0 * g.Term2 / maxGrade) / 2)
                    : 0;
                student.Grade = Utilities.CalculateGrade(avgGrade);
            }
            return studentsDto;

        }

        public async Task<ServicesResult<StudentDto>> GetStudent(int id)
        {
            var student = await studentRepo.GetStudent(id);
            StudentDto studentDto = mapper.Map<StudentDto>(student);

            int maxGrade = _configuration.GetValue<int>("MaxGrade");
            foreach (var grade in studentDto.Grades)
            {
                grade.Total = grade.Term1 + grade.Term2;
                grade.Grade = Utilities.CalculateGrade(100.0 * grade.Total.Value / (2 * maxGrade));
            }
            if (studentDto == null)
            {
                return ServicesResult<StudentDto>.Failure("Not Found");
            }

            return ServicesResult<StudentDto>.Successed(studentDto, "succeeded");
        }

        public async Task<ServicesResult<string>> PostStudent(CreateStudentDto studentDto)
        {
            if (await studentRepo.NationalIdExistsForAnotherStudentAsync(studentDto.NationalID))
            {
                return ServicesResult<string>.Failure("National ID already exists");
            }
            Student student = mapper.Map<Student>(studentDto);
            await studentRepo.PostStudent(student);
            return ServicesResult<string>.Successed(default, "Added Successfully");
        }

        public async Task<ServicesResult<string>> PutStudent(int id, UpdateStudentDto studentDto)
        {
            if (id != studentDto.StudentID)
            {
                return ServicesResult<string>.Failure("Bad Request");
            }

            if (await studentRepo.NationalIdExistsForAnotherStudentAsync(studentDto.NationalID, id))
            {
                return ServicesResult<string>.Failure("National ID already exists");
            }

            Student student = mapper.Map<Student>(studentDto);
            await studentRepo.PutStudent(id, student);
            return ServicesResult<string>.Successed(default, "Updated Successfully");
        }

        public async Task<ServicesResult<string>> DeleteStudent(int id)
        {
            var student = await studentRepo.DeleteStudent(id);
            if (student == null)
            {
                return ServicesResult<string>.Failure("Not Found");
            }
            return ServicesResult<string>.Successed(default, "deleted successfully");
        }

    }
}
