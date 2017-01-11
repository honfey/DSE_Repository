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
    [Authorize(Roles = "Admin, Sub Admin")]
    public class ClassStudentsController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: ClassStudents
        public ActionResult Index(int? id,int? Search)
        {
            if (Search == null)
            {
                var classStudents = db.ClassStudents.Include(c => c.Course_Module).Include(c => c.Student).OrderBy(x => x.Course_ModuleId).Where(x => x.Status == true);
                return View(classStudents.ToList());
            }
            else
            {
                var convert = Convert.ToBoolean(Search);
                var resultName = db.ClassStudents.Include(c => c.Course_Module).Include(c => c.Student).OrderBy(x => x.Course_ModuleId).Where(x => x.Status == convert);
                return View(resultName.ToList());
            }

            
        }

        public ActionResult CreateNewDetail(int? id, DateTime id2)
        {
            var getdata = db.ClassStudents.Where(x => x.Course_ModuleId == id && x.CreateDate == id2);
            return View(getdata);

        }

        public ActionResult deletecreate(int? id)
        {
            var select = db.ClassStudents.Where(x => x.Course_ModuleId == id);

            foreach (var item in select.ToList())
            {
                
                var finding = db.ClassStudents.Single(x => x.Course_ModuleId == item.Course_ModuleId && x.StudentId == item.StudentId);
                finding.Status = false;
                db.Entry(finding).State = EntityState.Modified;
            }
            //ClassStudent classStudent = db.ClassStudents.Find(id);
            //db.ClassStudents.Remove(classStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
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

            var studentName = from s in db.Students
                              select new { s.Id, Name = s.Name + "(" + s.StudentId + ")" };

            ViewBag.Course_ModuleId = new SelectList(moduleName, "ID", "Name");
            ViewBag.StudentId = new MultiSelectList(studentName, "ID", "Name");



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
                    if (classStudent.Status == null)
                    {
                        classStudent.Status = Convert.ToBoolean(1);
                    }
                    List<ClassStudent> cs = new List<ClassStudent>();


                    DateTime todaydate = DateTime.Now.Date;

                    var checking = db.ClassStudents.Any(x => x.Course_ModuleId == classStudent.Course_ModuleId && x.CreateDate == todaydate);
                    if (checking)
                    {
                        var moduleName = from l in db.Course_Module
                                         join c in db.Modules on l.ModuleId equals c.ModuleCode
                                         select new { l.Id, Name = l.CourseId + "  (" + c.ModuleCode + ")" };

                        ModelState.AddModelError("", "You have already create THIS class today !");
                        ViewBag.Course_ModuleId = new SelectList(moduleName, "ID", "Name");
                        ViewBag.StudentId = new MultiSelectList(db.Students, "ID", "Name");
                        return View(classStudent);
                    }
                    else
                    {


                        foreach (var i in classStudent.StudentList)
                        {

                            cs.Add(new ClassStudent { StudentId = i, Course_ModuleId = classStudent.Course_ModuleId, Day = classStudent.Day, Exam_Day = 1, Trial_Day = 1, Project_Day = 1, CreateDate = DateTime.Now, Status = true });
                        }
                        db.ClassStudents.AddRange(cs);
                    }
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
