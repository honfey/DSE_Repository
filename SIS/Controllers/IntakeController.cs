using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIS.Models;

namespace SIS.Controllers
{
    public class IntakeController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: Intake
        public ActionResult Index()
        {
            var intakes = db.Intakes.Include(i => i.Course).Include(i => i.Month).Include(i => i.Year);
            return View(intakes.ToList());
        }

        // GET: Intake/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intake intake = db.Intakes.Find(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // GET: Intake/Create
        public ActionResult Create()
        {
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "Name");
            ViewBag.MonthId = new SelectList(db.Months, "Id", "Month1");
            ViewBag.YearId = new SelectList(db.Years, "Id", "Year1");
            return View();
        }

        // POST: Intake/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,YearId,MonthId,CourseCode")] Intake intake)
        {
            if (ModelState.IsValid)
            {
                db.Intakes.Add(intake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "Name", intake.CourseCode);
            ViewBag.MonthId = new SelectList(db.Months, "Id", "Month1", intake.MonthId);
            ViewBag.YearId = new SelectList(db.Years, "Id", "Year1", intake.YearId);
            return View(intake);
        }

        // GET: Intake/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intake intake = db.Intakes.Find(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "Name", intake.CourseCode);
            ViewBag.MonthId = new SelectList(db.Months, "Id", "Month1", intake.MonthId);
            ViewBag.YearId = new SelectList(db.Years, "Id", "Year1", intake.YearId);
            return View(intake);
        }

        // POST: Intake/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,YearId,MonthId,CourseCode")] Intake intake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(intake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseCode = new SelectList(db.Courses, "CourseCode", "Name", intake.CourseCode);
            ViewBag.MonthId = new SelectList(db.Months, "Id", "Month1", intake.MonthId);
            ViewBag.YearId = new SelectList(db.Years, "Id", "Year1", intake.YearId);
            return View(intake);
        }

        // GET: Intake/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Intake intake = db.Intakes.Find(id);
            if (intake == null)
            {
                return HttpNotFound();
            }
            return View(intake);
        }

        // POST: Intake/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Intake intake = db.Intakes.Find(id);
            db.Intakes.Remove(intake);
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
