using AutoMapper;
using Business_Logic_Layer.Dtos;
using Data_Access_Layer.Models;
using Data_Access_Layer.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class GradeService : IGradeService
    {
        private IGradeRepo gradeRepo;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public GradeService(IGradeRepo _gradeRepo,
            IMapper mapper,
            IConfiguration configuration)
        {
            gradeRepo = _gradeRepo;
            this.mapper = mapper;
            _configuration = configuration;
        }
        public async Task<ServicesResult<string>> PutGrade(int id, ChildGradeDto gradeDto)
        {
            Grade grade = mapper.Map<Grade>(gradeDto);

            var gradeId = await gradeRepo.GetStudentGradeId(gradeDto.StudentID, gradeDto.Subject);
            if (gradeId == 0)
            {
                gradeRepo.Add(grade);
            }
            else
            {
                grade.GradeID = gradeId;
                gradeRepo.Update(grade);
            }

            await gradeRepo.SaveChangesAsync();

            return ServicesResult<string>.Successed(default, "updated Successfully");
        }

        public async Task<ServicesResult<List<GradeDto>>> GetAll()
        {
            var grades = await gradeRepo.GetAllAsync();
            var gradesDto = mapper.Map<IEnumerable<GradeDto>>(grades);

            int maxGrade = _configuration.GetValue<int>("MaxGrade");
            foreach (var grade in gradesDto)
            {
                grade.Total = grade.Term1 + grade.Term2;
                grade.Grade = Utilities.CalculateGrade(100.0 * grade.Total / (2 * maxGrade));
            }

            return ServicesResult<List<GradeDto>>.Successed(gradesDto.ToList(), "succeeded");
        }

        public Task<ServicesResult<List<string>>> GetAllSubjects()
        {
            throw new NotImplementedException();
        }
    }
}
