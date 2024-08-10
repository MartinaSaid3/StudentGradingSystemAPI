using Data_Access_Layer.Models;
using System.Text.Json.Serialization;

namespace Business_Logic_Layer.Dtos
{
    public class StudentDto
    {
        [JsonPropertyName("studentID")]
        public int StudentID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nationalID")]
        public string NationalID { get; set; }

        [JsonPropertyName("academicYear")]
        public string AcademicYear { get; set; }

        [JsonPropertyName("grades")]

        public ICollection<ChildGradeDto> Grades { get; set; }
        public string Grade { get; set; }
    }
}
