using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using TuitionClassProject.Models;
using TuitionClassProject.ViewModels;

namespace TuitionClassProject.Controllers
{
    public class StudentsController : Controller
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Students
        public ActionResult Index()
        {
            var students = _context.Students.Include(s => s.Category).ToList();

            return View(students);
        }

        public ActionResult StudentForm()
        {
            var categories = _context.Categories.ToList();

            var viewModel = new StudentFormViewModel()
            {
                Categories = categories
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new StudentFormViewModel()
                {
                    Categories = _context.Categories.ToList(),
                    Student = student
                };

                return View("StudentForm", viewModel);
            }

            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);

                studentInDb.Name = student.Name;
                studentInDb.IndexNumber = student.IndexNumber;
                studentInDb.Email = student.Email;
                studentInDb.ContactNumber = student.ContactNumber;
                studentInDb.CategoryId = student.CategoryId;
                studentInDb.IsActive = student.IsActive;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Students");
        }

        public ActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
            {
                return HttpNotFound();
            }

            var viewModel = new StudentFormViewModel
            {
                Student = student,
                Categories = _context.Categories.ToList()
            };

            return View("StudentForm", viewModel);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);
            Response.Write(studentInDb);

            if (studentInDb != null)
            {
                _context.Students.Remove(studentInDb);
                _context.SaveChanges();

            }



            return RedirectToAction("Index", "Students");

        }
    }
}