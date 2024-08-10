using AutoMapper;
using Business_Logic_Layer.Dtos;
using Data_Access_Layer.Models;
namespace Business_Logic_Layer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Student, ChildStudentDto>();
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Grade, ChildGradeDto>();
            CreateMap<Grade, GradeDto>();
            CreateMap<StudentDto, Student>();
            CreateMap<ChildGradeDto, Grade>();
        }
    }
}
