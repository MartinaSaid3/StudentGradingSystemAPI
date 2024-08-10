using Data_Access_Layer.Models;

namespace Data_Access_Layer.Repo;

public interface IGradeRepo
{
    Task SaveChangesAsync();
    Task<int> GetStudentGradeId(int studentID, string subject);
    void Update(Grade grade);
    void Add(Grade grade);
    Task<IEnumerable<Grade>> GetAllAsync();
}
