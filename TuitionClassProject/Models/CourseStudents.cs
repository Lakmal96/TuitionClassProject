using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuitionClassProject.Models
{
    public class CourseStudents
    {
        public Course Course { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public int StudentId { get; set; }
        
    }
}