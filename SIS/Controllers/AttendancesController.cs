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


namespace SIS.Controllers
{
    public class AttendancesController : Controller
    {
        private SISEntities db = new SISEntities();


        public ActionResult MarkAttendance(Attendance att, int id)
        {
            var getClassStudentID = db.ClassStudents.Where(x => x.Course_ModuleId == id);
            DateTime? TodayDate = DateTime.Now.Date;
            var list = new List<Attendance>();



            foreach (var item in getClassStudentID.ToList())
            {
                int ClassId = Convert.ToInt32(item.Id);

                if (db.Attendances.Any(x => x.ClassStudentId == ClassId && x.TodayDate == TodayDate))
                {

                }
                else
                {
                    att.ClassStudentId = ClassId;
                    att.TodayDate = DateTime.Now.Date;
                    db.Attendances.Add(att);
                    db.SaveChanges();
                }
            }

            foreach (var items in getClassStudentID.ToList())
            {
                int ClassIDs = Convert.ToInt32(items.Id);

                var TodayAttendance = db.Attendances.Where(x => x.ClassStudentId == ClassIDs && x.TodayDate == TodayDate);
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
            var haha = db.Attendances.OrderBy(x => x.TodayDate).Where(a => a.ClassStudent.Course_ModuleId == id && a.TodayDate != null).Select(x => x.TodayDate).Distinct().ToList();
            ViewData["DateList"] = haha;

            //ViewData["StudentList"] 

            //var stuList = new List<Attendance>();

            if (id > 0)
            {

                var resultStudentID = db.Attendances.OrderBy(x => x.ClassStudent.Student.Name).ThenBy(x => x.TodayDate).Where(a => a.ClassStudent.Course_ModuleId == id);



                return View(resultStudentID);
            }
            else
            {
                return View(new List<Attendance>());
            }


        }

        public ActionResult CheckIndividualAttendance(int id)
        {
            var haha = db.Attendances.OrderBy(x => x.TodayDate).Where(a => a.ClassStudentId == id).Select(x => x.TodayDate).Distinct().ToList();
            ViewData["DateList"] = haha;

            if (id > 0)
            {
                var resultStudentID = db.Attendances.OrderBy(x => x.ClassStudent.Student.Name).ThenBy(x => x.TodayDate).Where(a => a.ClassStudentId == id);
                return View(resultStudentID);

            }
            else
            {
                return View(new List<Attendance>());
            }
        }

        public ActionResult ClassAvailable(int? Search)
        {
            //ViewBag.Status = new SelectList(db.Course_Module, "Id", "Status").Distinct();
            //ViewBag.TrueFalse = (from r in db.Course_Module
            //                select r.Status != null).Distinct().ToList();

            if (Search == null)
            {
                var course_Module = db.Course_Module.Include(c => c.Course).Include(c => c.Module).Include(c => c.Trainer).Where(x => x.Status == true);
                return View(course_Module.ToList());
            }
            else
            {
                var convert = Convert.ToBoolean(Search);
                var resultName = db.Course_Module.Where(x => x.Status == convert);
                return View(resultName.ToList());
            }
        }

        public ActionResult CheckChoise()
        {
            var Example = db.Course_Module;
            return View(Example);
        }

        public ActionResult CheckIndividual(int id)
        {
            var classStudent = db.ClassStudents.Where(c => c.Course_ModuleId == id);

            return View(classStudent);
        }        

        public ActionResult CSS(string SearchIC, string SearchID, string SearchName)
        {
            if (!string.IsNullOrEmpty(SearchIC) && !string.IsNullOrEmpty(SearchID) && !string.IsNullOrEmpty(SearchName))
            {                                
                var studentName = db.Students.Where(x => x.IC.ToString().Contains(SearchIC) && x.Id.ToString().Contains(SearchID) && x.Name.Contains(SearchName));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchIC) && !string.IsNullOrEmpty(SearchID))
            {
                
                var studentName = db.Students.Where(x => x.IC.ToString().Contains(SearchIC) && x.Id.ToString().Contains(SearchID));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchID) && !string.IsNullOrEmpty(SearchName))
            {                
                var studentName = db.Students.Where(x => x.Name.Contains(SearchName) && x.Id.ToString().Contains(SearchID));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchName) && !string.IsNullOrEmpty(SearchIC))
            {
                
                var studentName = db.Students.Where(x => x.Name.Contains(SearchName) && x.IC.ToString().Contains(SearchIC));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchIC))
            {                
                var studentIC = db.Students.Where(x => x.IC.ToString().Contains(SearchIC));
                return View(studentIC);
            }
            else if (!string.IsNullOrEmpty(SearchID))
            {                
                var studentId = db.Students.Where(x => x.Id.ToString().Contains(SearchID));
                return View(studentId);
            }
            else if (!string.IsNullOrEmpty(SearchName))
            {
                var studentName = db.Students.Where(x => x.Name.Contains(SearchName));
                return View(studentName);
            }
            else
            {
                return View(new List<Student>());
            }               

            

        }

        public ActionResult CSSM(int id)
        {
            var module = db.ClassStudents.Where(x => x.StudentId == id);


            return View(module);
        }

        public ActionResult MarkBack(Attendance att, int id)
        {
            var getClassStudentID = db.ClassStudents.Where(x => x.Course_ModuleId == id);
            DateTime? TodayDate = DateTime.Now.Date;
            var list = new List<Attendance>();



            foreach (var item in getClassStudentID.ToList())
            {
                int ClassId = Convert.ToInt32(item.Id);

                if (db.Attendances.Any(x => x.ClassStudentId == ClassId && x.TodayDate == null))
                {

                }
                else
                {
                    att.ClassStudentId = ClassId;
                    db.Attendances.Add(att);
                    db.SaveChanges();
                }
                
            }

                foreach (var items in getClassStudentID.ToList())
                {
                    int ClassIDs = Convert.ToInt32(items.Id);
                // must all null
                    var TodayAttendance = db.Attendances.Where(x => x.ClassStudentId == ClassIDs && x.TodayDate == null);
                    list.AddRange(TodayAttendance);

                }
                return View(list);
            }

        






        //Useless

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
