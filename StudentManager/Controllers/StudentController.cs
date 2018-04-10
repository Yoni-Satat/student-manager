using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManager.DAL;
using StudentManager.Models;
using StudentManager.Repos;
using PagedList;

namespace StudentManager.Controllers
{
    public class StudentController : Controller
    {
        // private SMContext db = new SMContext();
        private IStudentRepository studentRepository;

        public StudentController()
        {
            studentRepository = new StudentRepository(new SMContext());
        }
        public StudentController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }


        // GET: Student
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParmFirstName = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.NameSortParmFirstName = sortOrder == "firstname" ? "firstname_desc" : "firstname";

            ViewBag.NameSortParmLastName = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.NameSortParmLastName = sortOrder == "lastname_desc" ? "lastname" : "lastname_desc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var students = from s in studentRepository.GetStudents()
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "firstname_desc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "firstname":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                case "lastname_desc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "lastname":
                    students = students.OrderBy(s => s.LastName);
                    break;
                default:
                    students = students.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(students.ToPagedList(pageNumber, pageSize));


        }

        // GET: Student/Details/5
        public ViewResult Details(int id)
        {
            Student student = studentRepository.GetStudentByID(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentID,FirstName,LastName,DateOfBirth,MatricNumber,Gender,Adjustments,Origin,YearOfStudy,ImageURL,IsPresent")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.InsertStudent(student);
                studentRepository.Save();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetStudentByID(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,FirstName,LastName,DateOfBirth,MatricNumber,Gender,Adjustments,Origin,YearOfStudy,ImageURL,IsPresent")] Student student)
        {
            if (ModelState.IsValid)
            {
                studentRepository.UpdateStudent(student);
                studentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = studentRepository.GetStudentByID(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = studentRepository.GetStudentByID(id);
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
