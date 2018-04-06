using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentManager.DAL;
using StudentManager.Models;

namespace StudentManager.Controllers
{
    public class AttendancyController : Controller
    {
        private SMContext db = new SMContext();

        // GET: Attendancy
        public async Task<ActionResult> Index()
        {
            var attendances = db.Attendances.Include(a => a.Location);
            return View(await attendances.ToListAsync());
        }

        // GET: Attendancy/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendancy attendancy = await db.Attendances.FindAsync(id);
            if (attendancy == null)
            {
                return HttpNotFound();
            }
            return View(attendancy);
        }

        // GET: Attendancy/Create
        public ActionResult Create()
        {
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Building");
            return View();
        }

        // POST: Attendancy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AttendancyID,LocationID,TutorName,LessonStart,LessonEnd,AttendancyDate,Comments")] Attendancy attendancy)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendancy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Building", attendancy.LocationID);
            return View(attendancy);
        }

        // GET: Attendancy/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendancy attendancy = await db.Attendances.FindAsync(id);
            if (attendancy == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Building", attendancy.LocationID);
            return View(attendancy);
        }

        // POST: Attendancy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AttendancyID,LocationID,TutorName,LessonStart,LessonEnd,AttendancyDate,Comments")] Attendancy attendancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendancy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LocationID = new SelectList(db.Locations, "LocationID", "Building", attendancy.LocationID);
            return View(attendancy);
        }

        // GET: Attendancy/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendancy attendancy = await db.Attendances.FindAsync(id);
            if (attendancy == null)
            {
                return HttpNotFound();
            }
            return View(attendancy);
        }

        // POST: Attendancy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Attendancy attendancy = await db.Attendances.FindAsync(id);
            db.Attendances.Remove(attendancy);
            await db.SaveChangesAsync();
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
