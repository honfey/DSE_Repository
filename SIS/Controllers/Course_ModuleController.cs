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
    public class Course_ModuleController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: Course_Module
        public ActionResult Index()
        {
            var course_Module = db.Course_Module.Include(c => c.Course).Include(c => c.Module).Include(c => c.Trainer);
            return View(course_Module.ToList());
        }

        // GET: Course_Module/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Module course_Module = db.Course_Module.Find(id);
            if (course_Module == null)
            {
                return HttpNotFound();
            }
            return View(course_Module);
        }

        // GET: Course_Module/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseCode", "Name");
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleCode", "Name");
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name");
            return View();
        }

        // POST: Course_Module/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CourseId,ModuleId,TrainerId,Status")] Course_Module course_Module)
        {
            if (ModelState.IsValid)
            {
                db.Course_Module.Add(course_Module);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseCode", "Name", course_Module.CourseId);
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleCode", "Name", course_Module.ModuleId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name", course_Module.TrainerId);
            return View(course_Module);
        }

        // GET: Course_Module/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Module course_Module = db.Course_Module.Find(id);
            if (course_Module == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseCode", "Name", course_Module.CourseId);
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleCode", "Name", course_Module.ModuleId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name", course_Module.TrainerId);
            return View(course_Module);
        }

        // POST: Course_Module/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CourseId,ModuleId,TrainerId,Status")] Course_Module course_Module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course_Module).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseCode", "Name", course_Module.CourseId);
            ViewBag.ModuleId = new SelectList(db.Modules, "ModuleCode", "Name", course_Module.ModuleId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "Name", course_Module.TrainerId);
            return View(course_Module);
        }

        // GET: Course_Module/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course_Module course_Module = db.Course_Module.Find(id);
            if (course_Module == null)
            {
                return HttpNotFound();
            }
            return View(course_Module);
        }

        // POST: Course_Module/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course_Module course_Module = db.Course_Module.Find(id);
            db.Course_Module.Remove(course_Module);
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
