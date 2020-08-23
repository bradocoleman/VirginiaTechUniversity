using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VirginiaTechUniversity.DAL;
using VirginiaTechUniversity.Models;

namespace VirginiaTechUniversity.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository studentRepository;

        public StudentController()
        {
            this.studentRepository = new StudentRepository(new SchoolContext());
        }

        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        // GET: Student
        public ActionResult Index()
        {
            return View(studentRepository.GetStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View(studentRepository.GetStudentById(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.InsertStudent(student);
                studentRepository.Save();
                return RedirectToAction("Index");
            }

            return Content("Model state is not valid");
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = studentRepository.GetStudentById(id);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,LastName,FirstMidName,EnrollmentDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.UpdateStudent(student);
                studentRepository.Save();
                return RedirectToAction("Index");
            }
            return Content("Model state is not valid");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {

            return View(studentRepository.GetStudentById(id));
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            studentRepository.DeleteStudent(id);
            studentRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            studentRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
