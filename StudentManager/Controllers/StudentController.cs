﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManager.DAL;
using StudentManager.Models;

namespace StudentManager.Controllers
{
    public class StudentController : Controller
    {
        private SMContext db = new SMContext();
        

        // GET: Student
        public ActionResult Index(string sortOrder)
        {
                        
            ViewBag.NameSortParm1 = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.NameSortParm1 = sortOrder == "firstname" ? "firstname_desc" : "firstname";

            ViewBag.NameSortParm2 = String.IsNullOrEmpty(sortOrder) ? "name" : "";
            ViewBag.NameSortParm2 = sortOrder == "lastname" ? "lastname_desc" : "lastname";

            var students = from s in db.Students
                           select s;
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
                    students = students.OrderBy(s => s.FirstName);
                    break;
            }
            return View(students.ToList());


        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
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
                db.Students.Add(student);
                db.SaveChanges();
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
            Student student = db.Students.Find(id);
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
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
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
            Student student = db.Students.Find(id);
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
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
