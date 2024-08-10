using Data_Access_Layer.Context;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repo;

public class GradeRepo : IGradeRepo
{
    private readonly GradeSystemContext _context;

    public GradeRepo(GradeSystemContext context)
    {
        _context = context;
    }

    public void Add(Grade grade)
        => _context.Set<Grade>().Add(grade);

    public void Update(Grade grade)
        => _context.Set<Grade>().Update(grade);


    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();

    public async Task<int> GetStudentGradeId(int studentID, string subject)
        => await _context
            .Grades
            .Where(g => g.StudentID == studentID && g.Subject == subject)
            .Select(g => g.GradeID)
            .FirstOrDefaultAsync();

    public async Task<IEnumerable<Grade>> GetAllAsync()
        => await _context.Grades
            .Include(g => g.Student)
            .ToListAsync();
}