using System.Text.Json.Serialization;

namespace Business_Logic_Layer.Dtos;

public class GradeDto
{
    [JsonPropertyName("studentID")]
    public int StudentID { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    [JsonPropertyName("term1")]
    public int Term1 { get; set; }

    [JsonPropertyName("term2")]
    public int Term2 { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("grade")]
    public string Grade { get; set; }

    public ChildStudentDto? Student { get; set; }
}