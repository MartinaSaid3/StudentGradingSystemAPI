using Business_Logic_Layer.Dtos;
using Data_Access_Layer.Context;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GradingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private Business_Logic_Layer.Services.IGradeService gradeService;

        public GradeController(Business_Logic_Layer.Services.IGradeService _gradeService)
        {
            gradeService = _gradeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetGrades()
        {
            var grades = await gradeService.GetAll();
            return Ok(grades.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(int id, ChildGradeDto gradeDto)
        {
            await gradeService.PutGrade(id, gradeDto);
            return Ok();
        }

    }
}
