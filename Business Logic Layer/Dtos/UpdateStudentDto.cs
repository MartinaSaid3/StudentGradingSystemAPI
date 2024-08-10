using System.Text.Json.Serialization;

namespace Business_Logic_Layer.Dtos;

public class UpdateStudentDto
{
    [JsonPropertyName("studentID")]
    public int StudentID { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("nationalID")]
    public string NationalID { get; set; }

    [JsonPropertyName("academicYear")]
    public string AcademicYear { get; set; }

}
