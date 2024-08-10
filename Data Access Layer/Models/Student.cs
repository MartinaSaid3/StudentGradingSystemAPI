using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data_Access_Layer.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string NationalID { get; set; }
        public string AcademicYear { get; set; }
        
        public ICollection<Grade> Grades { get; set; }
    }
}
