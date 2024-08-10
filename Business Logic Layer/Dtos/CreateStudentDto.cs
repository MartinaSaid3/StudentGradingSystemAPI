using System.Text.Json.Serialization;

namespace Business_Logic_Layer.Dtos;

public class CreateStudentDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("nationalID")]
    public string NationalID { get; set; }

    [JsonPropertyName("academicYear")]
    public string AcademicYear { get; set; }

}
