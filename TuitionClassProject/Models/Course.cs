using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TuitionClassProject.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(15)]
        public string Duration { get; set; }

        [Required]
        [StringLength(15)]
        public string Schedule { get; set; }

        public Category Category { get; set; }

        public byte CategoryId { get; set; }

        public Instructor Instructor { get; set; }

        public int InstructorId { get; set; }

        public ICollection<CourseStudents> CourseStudents { get; set; }

    }
}