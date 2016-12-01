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
    public class CourseWorksController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: CourseWorks
        public ActionResult Index()
        {
            var courseWorks = db.CourseWorks.Include(c => c.ClassStudent).Include(c => c.Course_Module).Include(c => c.ModuleStandard).Include(c => c.TestType);
            return View(courseWorks.ToList());
        }

        // GET: CourseWorks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return HttpNotFound();
            }
            return View(courseWork);
        }

        // GET: CourseWorks/Create
        public ActionResult Create()
        {
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id");
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId");
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName");
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name");
            return View();
        }

        // POST: CourseWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassStudentId,Course_ModuleId,TestTypeId,ModuleStandardId,Marks")] CourseWork courseWork)
        {
            if (ModelState.IsValid)
            {
                db.CourseWorks.Add(courseWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", courseWork.Course_ModuleId);
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", courseWork.ModuleStandardId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name", courseWork.TestTypeId);
            return View(courseWork);
        }

        // GET: CourseWorks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", courseWork.Course_ModuleId);
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", courseWork.ModuleStandardId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name", courseWork.TestTypeId);
            return View(courseWork);
        }

        // POST: CourseWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassStudentId,Course_ModuleId,TestTypeId,ModuleStandardId,Marks")] CourseWork courseWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", courseWork.Course_ModuleId);
            ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", courseWork.ModuleStandardId);
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name", courseWork.TestTypeId);
            return View(courseWork);
        }

        // GET: CourseWorks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CourseWork courseWork = db.CourseWorks.Find(id);
            if (courseWork == null)
            {
                return HttpNotFound();
            }
            return View(courseWork);
        }

        // POST: CourseWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CourseWork courseWork = db.CourseWorks.Find(id);
            db.CourseWorks.Remove(courseWork);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ShowClass()
        {          
            return View(db.Course_Module.ToList());
        }

        public ActionResult ShowStudent(int id)
        {
            var ClassStudent = db.ClassStudents.Where(x => x.Course_ModuleId == id);
            return View(ClassStudent.ToList());
        }

        //[Authorize]
        public ActionResult MarkMarks(CourseWork cw1, int id, int id2)
        {
            ViewBag.TT = new SelectList(db.TestTypes, "Id", "Name");
            //ViewBag.MT = new SelectList(db.MarkTypes, "Id", "Name");

            var checkCount = db.ModuleStandards.Where(q => q.Course_ModuleId == id2); //5 count
            var listCourseWork = new List<CourseWork>();

            foreach (var item in checkCount.ToList())
            {
                var checking2 = db.CourseWorks.Any(a => a.ClassStudentId == id && a.Course_ModuleId == id2 && a.ModuleStandardId == item.Id);
                if (checking2)
                {

                }
                else
                {
                    cw1.ClassStudentId = id;
                    cw1.Course_ModuleId = id2;
                    cw1.ModuleStandardId = item.Id;
                    db.CourseWorks.Add(cw1);
                    db.SaveChanges();
                }
            };

            foreach (var item2 in checkCount.ToList())
            {
                var show = db.CourseWorks.Where(a => a.ClassStudentId == id && a.Course_ModuleId == id2 && a.ModuleStandardId == item2.Id);
                listCourseWork.AddRange(show);
            }

            return View(listCourseWork);
        }

        [HttpPost]
        public ActionResult MarkMarks(List<CourseWork> courseWork)
        {
            if (ModelState.IsValid)
            {
                foreach (var cw in courseWork)
                {
                    db.Entry(cw).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseWork);
        }

        public ActionResult PassToMS()
        {
            return RedirectToRoute(new { controller = "ModuleStandards", action = "ShowStandard" });
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
