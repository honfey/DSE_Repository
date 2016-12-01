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
    public class ClassStudentsController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: ClassStudents
        public ActionResult Index(int? id)
        {
            var classStudents = db.ClassStudents.Include(c => c.Course_Module).Include(c => c.Student);
            return View(classStudents.ToList());
        }

        // GET: ClassStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent classStudent = db.ClassStudents.Find(id);
            if (classStudent == null)
            {
                return HttpNotFound();
            }
            return View(classStudent);
        }

        // GET: ClassStudents/Create
        public ActionResult Create()
        {
            var moduleName = from l in db.Course_Module
                             join c in db.Modules on l.ModuleId equals c.ModuleCode
                             select new { l.Id, Name = l.CourseId + "  (" + c.ModuleCode + ")" };

            ViewBag.Course_ModuleId = new SelectList(moduleName, "ID", "Name");
            ViewBag.StudentId = new MultiSelectList(db.Students, "ID", "Name");



            return View();
        }

        // POST: ClassStudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassStudent classStudent)
        {
            if (ModelState.IsValid)
            {
                if(classStudent.StudentList != null && classStudent.StudentList.Count() > 0)
                {
                    List<ClassStudent> cs = new List<ClassStudent>();
                    foreach (var i in classStudent.StudentList)
                        cs.Add(new ClassStudent { StudentId = i, Course_ModuleId = classStudent.Course_ModuleId, Day = classStudent.Day , Exam_Day = 1, Trial_Day =1 , Project_Day =1});

                    db.ClassStudents.AddRange(cs);
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", classStudent.Course_ModuleId);
            ViewBag.StudentId = new SelectList(db.Course_Module, "Id", "StudentId", classStudent.StudentId);
            return View(classStudent);
        }

        // GET: ClassStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent classStudent = db.ClassStudents.Find(id);
            if (classStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", classStudent.Course_ModuleId);
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", classStudent.StudentId);
            return View(classStudent);
        }

        // POST: ClassStudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassStudentId,Course_ModuleId,StudentId")] ClassStudent classStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", classStudent.Course_ModuleId);
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", classStudent.StudentId);
            return View(classStudent);
        }

        // GET: ClassStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent classStudent = db.ClassStudents.Find(id);
            if (classStudent == null)
            {
                return HttpNotFound();
            }
            return View(classStudent);
        }

        // POST: ClassStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClassStudent classStudent = db.ClassStudents.Find(id);
            db.ClassStudents.Remove(classStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CIndex(int? id)
        {

            return View(db.ClassStudents.Where(x=> x.Course_ModuleId == id).ToList());
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

        public ActionResult Pass(int id)
        {
            return RedirectToRoute(new { Controller = "ModuleStandards", Action = "Add", id = id });
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
