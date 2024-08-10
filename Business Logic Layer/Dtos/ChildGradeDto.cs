using Data_Access_Layer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Dtos
{
    public class ChildGradeDto
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
        public int? Total { get; set; }

        [JsonPropertyName("grade")]
        public string? Grade { get; set; }
    }
}
