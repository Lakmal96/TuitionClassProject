using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuitionClassProject.Models
{
    public class InstructorStudents
    {
        public Instructor Instructor { get; set; }

        public Student Student { get; set; }

        public int InstructorId { get; set; }

        public int StudentId { get; set; }
    }
}