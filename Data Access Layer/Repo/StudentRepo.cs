using Data_Access_Layer.Context;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repo
{
    public class StudentRepo : IStudentRepo
    {
        private readonly GradeSystemContext _context;

        public StudentRepo(GradeSystemContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetStudents()
        {
            var students = await _context.Students.Include(s => s.Grades).ToListAsync();
            return students;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await _context.Students.Include(s => s.Grades).FirstOrDefaultAsync(s => s.StudentID == id);
            return student;
        }

        public async Task PostStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task PutStudent(int id, Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return null;
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return student;
        }

        public Task<bool> NationalIdExistsForAnotherStudentAsync(string nationalID, int excludedStudentId = 0)
            => _context.Students
                .Where(s => s.StudentID != excludedStudentId)
                .AnyAsync(s => s.NationalID == nationalID);
    }
}
