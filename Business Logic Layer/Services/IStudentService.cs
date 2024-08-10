using Business_Logic_Layer.Dtos;
using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public interface IStudentService
    {
        Task<List<StudentDto>> GetStudents();
        Task<ServicesResult<StudentDto>> GetStudent(int id);
        Task<ServicesResult<string>> PostStudent(CreateStudentDto studentDto);
        Task<ServicesResult<string>> PutStudent(int id, UpdateStudentDto studentDto);
        Task<ServicesResult<string>> DeleteStudent(int id);
    }
}
