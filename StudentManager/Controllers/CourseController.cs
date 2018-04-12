using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using StudentManager.Models;
using StudentManager.ViewModels;
using StudentManager.Repos;

namespace StudentManager.Controllers
{
    public class CourseController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        // GET: Course
        public ActionResult Index(int? id)
        {
            var viewModel = new CourseIndexData();
            viewModel.Courses = unitOfWork.CourseRepository.Get(includeProperties: "Lessons");

            if (id != null)
            {
                ViewBag.CourseID = id.Value;
                viewModel.Lessons = viewModel.Courses.Where(
                    c => c.CourseID == id.Value).Single().Lessons;
            }
            return View(viewModel);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseID,Title,Level")] Course course)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.CourseRepository.Insert(course);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            return View(course);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseID,Title,Level,LessonID")] Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CourseRepository.Update(course);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateLessonsTable(course.Lessons);
            return View(course);
        }
        
        private void PopulateLessonsTable(object selectedLesson = null)
        {
            var lessonsQuery = unitOfWork.LessonRepository.Get(
                orderBy: q => q.OrderBy(l => l.Topic));
            ViewBag.LessonID = new SelectList(lessonsQuery, "LessonID", "Name", selectedLesson);
        }

        private void PopulateCoursesTable(object selectedCourse = null)
        {
            var courseQuery = unitOfWork.CourseRepository.Get(
                orderBy: q => q.OrderBy(c => c.Title));
            ViewBag.CourseID = new SelectList(courseQuery, "CourseID", "Lessons", selectedCourse);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = unitOfWork.CourseRepository.GetByID(id);
            unitOfWork.CourseRepository.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
