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
    [Authorize(Roles = "Admin, Trainer")]
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
            //var CourseModuleName = from cm in db.Course_Module
            //                       join c in db.Courses on cm.CourseId equals c.CourseCode
            //                       join ml in db.Modules on cm.ModuleId equals ml.ModuleCode
            //                       select new { cm.Id, Name = c.Name + "(" + ml.Name + ")" };
            //ViewBag.CMName = new SelectList(CourseModuleName, "Id", "Name");
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
            var n = db.Course_Module.Find(id);
            var c = n.Module.Name + "(" + n.Module.ModuleCode + ")";
            ViewData["name"] = c;           
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name");
            return View(ms);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(List<ModuleStandard> mss,int? id )
        {
            if (ModelState.IsValid)
            {
                var total = (int?)0;
                foreach (var item in mss)
                {
                    total += item.Marks;
                }
                if (total == 100)
                {
                    foreach (var i in mss)
                    {
                        db.ModuleStandards.Add(i);
                    }
                    db.SaveChanges();
                    ViewBag.Message = "Data successfully saved!";
                    return RedirectToAction("ShowStandard");
                }
                //ModelState.Clear();
                ////mss = new List<ModuleStandard> { new ModuleStandard { Course_ModuleId = id, MarkTypeId = 0, Mark = 0 } };
                else
                {                   
                    ViewBag.alert = "Marks must be 100%";
                    var n = db.Course_Module.Find(id);
                    var c = n.Module.Name;
                    ViewData["name"] = c;
                    ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name");
                    return View(mss);
                }
            }
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name");           
            return View(mss);
        }

        public ActionResult ShowStandard(int? Search)
        {
            if(Search == null)
            {
                var standard = db.ClassStudents.OrderBy(x=>x.Course_ModuleId).Where(x => x.Status == true);
                return View(standard.ToList());
            }
            else
            {
                var convert = Convert.ToBoolean(Search);
                var resultName = db.ClassStudents.OrderBy(x => x.Course_ModuleId).Where(x => x.Status == convert);
                return View(resultName.ToList());
            }
           
        }

        public ActionResult EditModuleStandard(int id)
        {                    
            ViewBag.MT = new SelectList(db.MarkTypes, "Id", "Name");
            var CheckModuleStandard = db.ModuleStandards.Where(x => x.Course_ModuleId == id);

            var CourseModuleName = db.Course_Module.Find(id);
            var cmName = CourseModuleName.Module.Name + "(" + CourseModuleName.Module.ModuleCode + ")";

            var total = (int?)0;
            foreach (var item in CheckModuleStandard)
            {
                total += item.Marks;
            }
            ViewData["int"] = total;
            ViewData["cmName"] = cmName;
            return View(CheckModuleStandard.ToList());

        }

        [HttpPost]
        public ActionResult EditModuleStandard(List<ModuleStandard> moduleStandard, int id)
        {
            if (ModelState.IsValid)
            {
                var total = (int?)0;
                foreach (var item in moduleStandard)
                {
                    total += item.Marks;
                }
                if (total == 100)
                {
                    if (moduleStandard != null && moduleStandard.Count() > 0)
                    {
                        foreach (var i in moduleStandard)
                        {
                            if (i.Id == 0)
                            {
                                db.Entry(i).State = EntityState.Added;
                            }
                            else
                            {
                                db.Entry(i).State = EntityState.Modified;
                            }
                        }
                    }                   
                    db.SaveChanges();
                    return RedirectToAction("ShowStandard");
                }
                else
                {
                    ViewData["int"] = total;
                    ViewBag.alert = "Total Marks must be 100%";
                    ViewBag.MT = new SelectList(db.MarkTypes, "Id", "Name");

                    var CourseModuleName = db.Course_Module.Find(id);
                    var cmName = CourseModuleName.Module.Name;
                    ViewData["cmName"] = cmName;
                    return View(moduleStandard);
                }
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
