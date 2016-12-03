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
    public class ModuleStandardsController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: ModuleStandards
        public ActionResult Index()
        {
            var moduleStandards = db.ModuleStandards.Include(m => m.Course_Module).Include(m => m.MarkType);
            return View(moduleStandards.ToList());
        }

        // GET: ModuleStandards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModuleStandard moduleStandard = db.ModuleStandards.Find(id);
            if (moduleStandard == null)
            {
                return HttpNotFound();
            }
            return View(moduleStandard);
        }

        // GET: ModuleStandards/Create
        public ActionResult Create()
        {
            var CourseModuleName = from cm in db.Course_Module
                                   join c in db.Courses on cm.CourseId equals c.CourseCode
                                   join ml in db.Modules on cm.ModuleId equals ml.ModuleCode
                                   select new { cm.Id, Name = c.Name + "(" + ml.Name + ")" };
            ViewBag.CMName = new SelectList(CourseModuleName, "Id", "Name");
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name");
            return View();
        }

        // POST: ModuleStandards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Course_ModuleId,MarkTypeId,LabName,Mark")] ModuleStandard moduleStandard)
        {
            if (ModelState.IsValid)
            {
                db.ModuleStandards.Add(moduleStandard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", moduleStandard.Course_ModuleId);
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name", moduleStandard.MarkTypeId);
            return View(moduleStandard);
        }

        //// GET: ModuleStandards/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ModuleStandard moduleStandard = db.ModuleStandards.Find(id);
        //    if (moduleStandard == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", moduleStandard.Course_ModuleId);
        //    ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name", moduleStandard.MarkTypeId);
        //    return View(moduleStandard);
        //}

        //// POST: ModuleStandards/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Course_ModuleId,MarkTypeId,LabName,Mark")] ModuleStandard moduleStandard)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(moduleStandard).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", moduleStandard.Course_ModuleId);
        //    ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name", moduleStandard.MarkTypeId);
        //    return View(moduleStandard);
        //}

        //// GET: ModuleStandards/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ModuleStandard moduleStandard = db.ModuleStandards.Find(id);
        //    if (moduleStandard == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(moduleStandard);
        //}

        //// POST: ModuleStandards/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    ModuleStandard moduleStandard = db.ModuleStandards.Find(id);
        //    db.ModuleStandards.Remove(moduleStandard);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult Add(int? id)
        {
            List<ModuleStandard> ms = new List<ModuleStandard> { new ModuleStandard { Course_ModuleId = id, MarkTypeId = 0, Marks = 0 } };
            var CourseModuleName = from cm in db.Course_Module
                                   join c in db.Courses on cm.CourseId equals c.CourseCode
                                   join ml in db.Modules on cm.ModuleId equals ml.ModuleCode
                                   select new { cm.Id, Name = c.Name + "(" + ml.Name + ")" };
            ViewBag.CMName = new SelectList(CourseModuleName, "Id", "Name");
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name");
            return View(ms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(List<ModuleStandard> mss)
        {
            if (ModelState.IsValid)
            {
                
                foreach (var i in mss)
                {
                    db.ModuleStandards.Add(i);
                }
                db.SaveChanges();
                ViewBag.Message = "Data successfully saved!";
                ModelState.Clear();
                //mss = new List<ModuleStandard> { new ModuleStandard { Course_ModuleId = id, MarkTypeId = 0, Mark = 0 } };
                return RedirectToAction("ShowStandard");
            }
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name");

            return View(mss);
        }

        public ActionResult ShowStandard()
        {
            return View(db.Course_Module.ToList());
        }

        public ActionResult EditModuleStandard(int id)
        {
            var cmName = from cm in db.Course_Module
                         join c in db.Courses on cm.CourseId equals c.CourseCode
                         join m in db.Modules on cm.ModuleId equals m.ModuleCode
                         select new { cm.Id, Name = c.Name + "(" + m.Name + ")" };

            ModuleStandard mS = db.ModuleStandards.Find(id);
            
            ViewBag.CM = new SelectList(cmName, "Id", "Name");
            ViewBag.MT = new SelectList(db.MarkTypes, "Id", "Name");
            var CheckModuleStandard = db.ModuleStandards.Where(x => x.Course_ModuleId == id);
            return View(CheckModuleStandard.ToList());

        }

        [HttpPost]
        public ActionResult EditModuleStandard(List<ModuleStandard> moduleStandard)
        {
            if (ModelState.IsValid)
            {
                
                foreach (var ms in moduleStandard)
                {
                    db.Entry(ms).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("ShowStandard");
            }
            return View(moduleStandard);
        }

        public ActionResult D(int id)
        {
            int rs = 0;
            var aa = db.ModuleStandards.Find(id);
            db.ModuleStandards.Remove(aa);
            rs = db.SaveChanges();

            return Json(new { deletedRow = rs }, JsonRequestBehavior.AllowGet);
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
