﻿using System.Text.Json.Serialization;

namespace Business_Logic_Layer.Dtos;

public class ChildStudentDto
{
    [JsonPropertyName("studentID")]
    public int StudentID { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("academicYear")]
    public string AcademicYear { get; set; }
}