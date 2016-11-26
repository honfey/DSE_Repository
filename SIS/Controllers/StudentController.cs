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
    public class StudentController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: Student
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Intake).Include(s => s.SPMResult);
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
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode");
            ViewBag.SPMResultId = new SelectList(db.SPMResults, "Id", "Id");
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StudentId,IntakeId,SPMResultId,Insurence,Name,Age,DOB,IC,Nationality,Gender,Status,PhoneNum,OtherPhoneNum,EmailAddress,Religion,SingleParent,MomName,MomEdu,MomWorkStatus,MomJob,MomFeildWork,MomSectorJob,MomSalary,FatherName,FatherEdu,FatherWorkStatus,FatherJob,FatherFeildWork,FatherSectorJob,FatherSalary,NumSibling,BirthOrd")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode", student.IntakeId);
            ViewBag.SPMResultId = new SelectList(db.SPMResults, "Id", "Id", student.SPMResultId);
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
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode", student.IntakeId);
            ViewBag.SPMResultId = new SelectList(db.SPMResults, "Id", "Id", student.SPMResultId);
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StudentId,IntakeId,SPMResultId,Insurence,Name,Age,DOB,IC,Nationality,Gender,Status,PhoneNum,OtherPhoneNum,EmailAddress,Religion,SingleParent,MomName,MomEdu,MomWorkStatus,MomJob,MomFeildWork,MomSectorJob,MomSalary,FatherName,FatherEdu,FatherWorkStatus,FatherJob,FatherFeildWork,FatherSectorJob,FatherSalary,NumSibling,BirthOrd")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode", student.IntakeId);
            ViewBag.SPMResultId = new SelectList(db.SPMResults, "Id", "Id", student.SPMResultId);
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
