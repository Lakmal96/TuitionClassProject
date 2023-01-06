using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TuitionClassProject.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(13)]
        public string IndexNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(10)]
        public string ContactNumber { get; set; }

        public bool IsActive { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Path")]
        public byte CategoryId { get; set; }

        public ICollection<InstructorStudents> InstructorStudents { get; set; }

        public ICollection<CourseStudents> CourseStudents { get; set; }

    }
}