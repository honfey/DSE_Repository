using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIS.Models;


namespace WebApplication1.Controllers
{
    public class AttendancesController : Controller
    {
        private SISEntities db = new SISEntities();


        public ActionResult MarkAttendance(Attendance att, int id)
        {
            var getClassStudentID = db.ClassStudents.Where(x => x.Course_ModuleId == id);
            DateTime? TodayDate = DateTime.Now;
            var list = new List<Attendance>();



            foreach (var item in getClassStudentID.ToList())
            {
                int ClassId = Convert.ToInt32(item.Id);

                if (db.Attendances.Any(x => x.ClassStudentId == ClassId && EntityFunctions.TruncateTime(x.MorningIn) == null && EntityFunctions.TruncateTime(x.MorningOut) == null && EntityFunctions.TruncateTime(x.AfternoonIn) == null && EntityFunctions.TruncateTime(x.AfternoonOut) == null))
                {

                }
                else if (db.Attendances.Any(x => x.ClassStudentId == ClassId && (EntityFunctions.TruncateTime(x.MorningIn) == null || EntityFunctions.TruncateTime(x.MorningOut) == null || EntityFunctions.TruncateTime(x.AfternoonIn) == null || EntityFunctions.TruncateTime(x.AfternoonOut) == null)))
                {
                    if (db.Attendances.Any(x => x.ClassStudentId == ClassId && ((EntityFunctions.TruncateTime(x.MorningIn) != EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.MorningOut) != EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.AfternoonIn) == null && EntityFunctions.TruncateTime(x.AfternoonOut) == null) || (EntityFunctions.TruncateTime(x.MorningIn) == null && EntityFunctions.TruncateTime(x.MorningOut) == null && EntityFunctions.TruncateTime(x.AfternoonIn) != EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.AfternoonOut) != EntityFunctions.TruncateTime(TodayDate)))))
                    {
                        if (db.Attendances.Any(x => x.ClassStudentId == ClassId && (EntityFunctions.TruncateTime(x.MorningIn) == EntityFunctions.TruncateTime(TodayDate) || EntityFunctions.TruncateTime(x.MorningOut) == EntityFunctions.TruncateTime(TodayDate) || EntityFunctions.TruncateTime(x.AfternoonIn) == EntityFunctions.TruncateTime(TodayDate) || EntityFunctions.TruncateTime(x.AfternoonOut) == EntityFunctions.TruncateTime(TodayDate))))
                        {

                        }
                        else
                        {
                            att.ClassStudentId = ClassId;
                            db.Attendances.Add(att);
                            db.SaveChanges();
                        }

                    }
                    else
                    {

                    }
                }
                else if (db.Attendances.Any(x => x.ClassStudentId == ClassId && (EntityFunctions.TruncateTime(x.MorningIn) == EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.MorningOut) == EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.AfternoonIn) == EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.AfternoonOut) == EntityFunctions.TruncateTime(TodayDate))))
                {

                }
                else if (db.Attendances.Any(x => x.ClassStudentId == ClassId && (EntityFunctions.TruncateTime(x.MorningIn) != EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.MorningOut) != EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.AfternoonIn) != EntityFunctions.TruncateTime(TodayDate) && EntityFunctions.TruncateTime(x.AfternoonOut) != EntityFunctions.TruncateTime(TodayDate))))
                {
                    att.ClassStudentId = ClassId;
                    db.Attendances.Add(att);
                    db.SaveChanges();
                }
                else
                {
                    att.ClassStudentId = ClassId;
                    db.Attendances.Add(att);
                    db.SaveChanges();
                }
                var TodayAttendance = db.Attendances.Where(x => x.ClassStudentId == ClassId && ((EntityFunctions.TruncateTime(x.MorningIn) == EntityFunctions.TruncateTime(TodayDate) || EntityFunctions.TruncateTime(x.MorningIn) == null) && (EntityFunctions.TruncateTime(x.MorningOut) == EntityFunctions.TruncateTime(TodayDate) || EntityFunctions.TruncateTime(x.MorningOut) == null) && (EntityFunctions.TruncateTime(x.AfternoonIn) == EntityFunctions.TruncateTime(TodayDate) || EntityFunctions.TruncateTime(x.AfternoonIn) == null) && (EntityFunctions.TruncateTime(x.AfternoonOut) == EntityFunctions.TruncateTime(TodayDate) || EntityFunctions.TruncateTime(x.AfternoonOut) == null))).ToList();

                list.AddRange(TodayAttendance);
            }


            return View(list);

        }

        [HttpPost]
        public ActionResult MarkAttendance(List<Attendance> att)
        {
            if (ModelState.IsValid)
            {
                foreach (var j in att)
                {
                    db.Entry(j).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("ClassAvailable");
            }
            return View(att);
        }


        // GET: Attendances
        public ActionResult CheckAttendance(int id)
        {
            var attendances = db.Attendances.Include(a => a.ClassStudent);
            if (id > 0)
            {

                var resultStudentID = db.Attendances.OrderBy(x => x.ClassStudent.Student.Name).Where(a => a.ClassStudent.Course_ModuleId == id);

                return View(resultStudentID);
            }
            else
            {
                return View(new List<Attendance>());
            }


        }

        public ActionResult ClassAvailable()
        {
            var course_Module = db.Course_Module.Include(c => c.Course).Include(c => c.Module).Include(c => c.Trainer);
            return View(course_Module.ToList());
        }





        //    return View(attendances.ToList());
        //}

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassStudentId,MorningIn,MorningOut,AfternoonIn,AfternoonOut")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId", attendance.ClassStudentId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId", attendance.ClassStudentId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassStudentId,MorningIn,MorningOut,AfternoonIn,AfternoonOut")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId", attendance.ClassStudentId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.Attendances.Find(id);
            db.Attendances.Remove(attendance);
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
