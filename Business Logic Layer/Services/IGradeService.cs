using Business_Logic_Layer.Dtos;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services;

public interface IGradeService
{
    Task<ServicesResult<List<GradeDto>>> GetAll();
    Task<ServicesResult<List<string>>> GetAllSubjects();
    Task<ServicesResult<string>> PutGrade(int id, ChildGradeDto gradeDto);
}
