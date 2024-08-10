using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Grade
    {
        public int GradeID { get; set; }
        public int StudentID { get; set; }
        public string Subject { get; set; }
        public int Term1 { get; set; }
        public int Term2 { get; set; }
        public Student Student { get; set; }
    }
}
