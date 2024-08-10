using Business_Logic_Layer.Dtos;
using Business_Logic_Layer.Services;
using Data_Access_Layer.Context;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService studentService;

        public StudentsController(IStudentService _studentService)
        {
            studentService = _studentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            var students = await studentService.GetStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            var result = await studentService.GetStudent(id);

            return Ok(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> PostStudent(CreateStudentDto studentDto)
        {
            var res = await studentService.PostStudent(studentDto);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, UpdateStudentDto studentDto)
        {
            var res = await studentService.PutStudent(id, studentDto);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var res = await studentService.DeleteStudent(id);
            return Ok(res);
        }
    }

}
