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
        public ActionResult Index(string search)
        {
            var cw = from c in db.CourseWorks
                     select c;
            if (!string.IsNullOrEmpty(search))
            {
                cw = cw.Where(c => c.TestType.Name.Contains(search));
            }
            var courseWorks = db.CourseWorks.Include(c => c.ClassStudent).Include(c => c.TestType).OrderBy(c => c.ClassStudent.Student.Name);
            return View(cw.ToList());
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
            var StudentName = from C in db.ClassStudents
                              join S in db.Students on C.StudentId equals S.Id
                              select new { C.Id, Name = S.Name };

            ViewBag.ClassStudentId = new SelectList(StudentName, "Id", "Name");
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name");
            return View();
        }

        // POST: CourseWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassStudentId,TestTypeId,WrittenTest,OralTest,Presentation,Assignment,Project,Total,Lab")] CourseWork courseWork)
        {
            if (ModelState.IsValid)
            {
                if (courseWork.Presentation == null && courseWork.Assignment == null)
                {
                    courseWork.Total = courseWork.WrittenTest + courseWork.OralTest + courseWork.Project;
                }
                else
                {
                    courseWork.Total = courseWork.WrittenTest + courseWork.Assignment + courseWork.Presentation + courseWork.Project;
                }              
                db.CourseWorks.Add(courseWork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
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
            ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name", courseWork.TestTypeId);
            return View(courseWork);
        }

        // POST: CourseWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassStudentId,TestTypeId,WrittenTest,OralTest,Presentation,Assignment,Project,Total,Lab")] CourseWork courseWork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(courseWork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
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

        public ActionResult EditList()
        {
            return View(db.CourseWorks.ToList());
        }

        [HttpPost]
        public ActionResult EditList(List<CourseWork> courseWork)
        {
            if (ModelState.IsValid)
            {
                CourseWork cc = new CourseWork();
                if (cc.Presentation == null && cc.Assignment == null)
                {
                    cc.Total = cc.WrittenTest + cc.OralTest + cc.Project;                  
                }
                else
                {
                    cc.Total = cc.WrittenTest + cc.Assignment + cc.Presentation + cc.Project;
                }             
                foreach (var cw in courseWork)
                {
                    db.Entry(cw).State = EntityState.Modified;
                }
                db.CourseWorks.Add(cc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(courseWork);
        }

        public ActionResult Pass(/*int id*/)
        {
            return RedirectToRoute(new { controller = "Images", action = "Create" });
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
