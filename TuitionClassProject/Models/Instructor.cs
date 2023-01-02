using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TuitionClassProject.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public string ProfilePicture { get; set; }

        public Category Category { get; set; }

        public byte CategoryId { get; set; }

        public Course Course { get; set; }
        
        public int CourseId { get; set; }

        public ICollection<InstructorStudents> InstructorStudents { get; set; }
    }
}