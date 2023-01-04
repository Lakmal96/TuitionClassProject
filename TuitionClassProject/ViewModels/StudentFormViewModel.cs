using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TuitionClassProject.Models;

namespace TuitionClassProject.ViewModels
{
    public class StudentFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Student Student { get; set; }
    }
}