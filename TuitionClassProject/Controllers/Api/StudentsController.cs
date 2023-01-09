using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TuitionClassProject.Models;

namespace TuitionClassProject.Controllers.Api
{
    public class StudentsController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        // DELETE: /api/students/1
        [HttpDelete]
        public IHttpActionResult DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
            {
                return NotFound();
            }

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
