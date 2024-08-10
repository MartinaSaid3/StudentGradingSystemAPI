using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repo
{
    public interface IStudentRepo
    {
        Task<List<Student>> GetStudents();
        Task<Student> GetStudent(int id);
        Task PostStudent(Student student);
        Task PutStudent(int id, Student student);
        Task<Student> DeleteStudent(int id);
        Task<bool> NationalIdExistsForAnotherStudentAsync(string nationalID, int excludedStudentId = 0);
    }
}
