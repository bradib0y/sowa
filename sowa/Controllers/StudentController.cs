using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using sowa.Models;
using System.Data.Entity;
using sowa.ViewModels;

namespace sowa.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext applicationDbContext;

        public StudentController()
        {
            this.applicationDbContext = new ApplicationDbContext();

            //if (!applicationDbContext.Students.Any()) {
            //    List<Student> students = new List<Student> {

            //        new Student{Name = "", Birthday = Convert.ToDateTime("1968-10-23"), IsSubscribedToNewsletter = false, MembershipType = applicationDbContext.Memb } },

            //    };
            //}
        }

        protected override void Dispose(bool disposing)
        {
            applicationDbContext.Dispose();
        }




        // GET: Student
        public ActionResult Details(int? id)
        {
            if (id == null) { RedirectToAction("Index"); }            
            
            Student student = applicationDbContext.Students.Include(s => s.MembershipType).FirstOrDefault(s => s.Id == id);
            return View(student);
            
        }

        public ActionResult Index()
        {
            List<Student> students = applicationDbContext.Students.Include(s => s.MembershipType).ToList();
            return View(students);
        }

        public ActionResult New()
        {
            var membershipTypes = applicationDbContext.MemberShipTypes.ToList();
            var viewModel = new StudentFormViewModel {
                MembershipTypes = membershipTypes
                
            };

            return View("StudentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (student.Id == 0) { applicationDbContext.Students.Add(student); }
            else {
                Student studentInDb = applicationDbContext.Students.Single(s => s.Id == student.Id);

                studentInDb.Birthday = student.Birthday;
                studentInDb.IsSubscribedToNewsletter = student.IsSubscribedToNewsletter;
                studentInDb.MembershipTypeId = student.MembershipTypeId;
                studentInDb.MembershipType = student.MembershipType;
                studentInDb.Name = student.Name;
                
            }
            applicationDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Student student = applicationDbContext.Students.SingleOrDefault(s => s.Id == id);

            if (student == null) { return HttpNotFound(); }

            StudentFormViewModel viewModel = new StudentFormViewModel {
                Student = student,
                MembershipTypes = applicationDbContext.MemberShipTypes.ToList()
            };

            return View("StudentForm", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            
            return RedirectToAction("Index");
        }
    }
}