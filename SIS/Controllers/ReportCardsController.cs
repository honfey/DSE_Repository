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
    public class ReportCardsController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: ReportCards
        public ActionResult Index()
        {
            var reportCards = db.ReportCards.Include(r => r.ClassStudent).Include(r => r.Course_Module).Include(r => r.CourseWork).Include(r => r.Intake).Include(r => r.ModuleStandard).Include(r => r.Student).Include(r => r.Trainer);
            return View(reportCards.ToList());
        }

        // GET: ReportCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportCard reportCard = db.ReportCards.Find(id);
            if (reportCard == null)
            {
                return HttpNotFound();
            }
            return View(reportCard);
        }

        // GET: ReportCards/Create
        public ActionResult Create()
        {
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id");
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId");
            ViewBag.CourseWorkId = new SelectList(db.CourseWorks, "Id", "Id");
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode");
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName");
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentId");
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "IC");
            return View();
        }

        // POST: ReportCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Course_ModuleId,StudentId,IntakeId,TrainerId,ClassStudentId,ModuleStandardId,CourseWorkId")] ReportCard reportCard)
        {
            if (ModelState.IsValid)
            {
                db.ReportCards.Add(reportCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", reportCard.ClassStudentId);
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", reportCard.Course_ModuleId);
            ViewBag.CourseWorkId = new SelectList(db.CourseWorks, "Id", "Id", reportCard.CourseWorkId);
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode", reportCard.IntakeId);
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", reportCard.ModuleStandardId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentId", reportCard.StudentId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "IC", reportCard.TrainerId);
            return View(reportCard);
        }

        // GET: ReportCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportCard reportCard = db.ReportCards.Find(id);
            if (reportCard == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", reportCard.ClassStudentId);
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", reportCard.Course_ModuleId);
            ViewBag.CourseWorkId = new SelectList(db.CourseWorks, "Id", "Id", reportCard.CourseWorkId);
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode", reportCard.IntakeId);
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", reportCard.ModuleStandardId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentId", reportCard.StudentId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "IC", reportCard.TrainerId);
            return View(reportCard);
        }

        // POST: ReportCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Course_ModuleId,StudentId,IntakeId,TrainerId,ClassStudentId,ModuleStandardId,CourseWorkId")] ReportCard reportCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", reportCard.ClassStudentId);
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", reportCard.Course_ModuleId);
            ViewBag.CourseWorkId = new SelectList(db.CourseWorks, "Id", "Id", reportCard.CourseWorkId);
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode", reportCard.IntakeId);
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", reportCard.ModuleStandardId);
            ViewBag.StudentId = new SelectList(db.Students, "Id", "StudentId", reportCard.StudentId);
            ViewBag.TrainerId = new SelectList(db.Trainers, "Id", "IC", reportCard.TrainerId);
            return View(reportCard);
        }

        // GET: ReportCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportCard reportCard = db.ReportCards.Find(id);
            if (reportCard == null)
            {
                return HttpNotFound();
            }
            return View(reportCard);
        }

        // POST: ReportCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportCard reportCard = db.ReportCards.Find(id);
            db.ReportCards.Remove(reportCard);
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
