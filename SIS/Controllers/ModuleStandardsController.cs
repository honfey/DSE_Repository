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
            var moduleStandards = db.ModuleStandards.Include(m => m.ClassStudent).Include(m => m.MarkType);
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
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id");
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name");
            return View();
        }

        // POST: ModuleStandards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassStudentId,MarkTypeId,Marks")] ModuleStandard moduleStandard)
        {
            if (ModelState.IsValid)
            {
                db.ModuleStandards.Add(moduleStandard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", moduleStandard.ClassStudentId);
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name", moduleStandard.MarkTypeId);
            return View(moduleStandard);
        }

        // GET: ModuleStandards/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", moduleStandard.ClassStudentId);
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name", moduleStandard.MarkTypeId);
            return View(moduleStandard);
        }

        // POST: ModuleStandards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassStudentId,MarkTypeId,Marks")] ModuleStandard moduleStandard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moduleStandard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", moduleStandard.ClassStudentId);
            ViewBag.MarkTypeId = new SelectList(db.MarkTypes, "Id", "Name", moduleStandard.MarkTypeId);
            return View(moduleStandard);
        }

        // GET: ModuleStandards/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: ModuleStandards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModuleStandard moduleStandard = db.ModuleStandards.Find(id);
            db.ModuleStandards.Remove(moduleStandard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditList()
        {           
            ViewBag.mat = new SelectList(db.MarkTypes, "Id", "Name");
            return View(db.ModuleStandards.ToList());
        }

        [HttpPost]
        public ActionResult EditList(List<ModuleStandard> moduleStandard)
        {
            if (ModelState.IsValid)
            {
                foreach (var ms in moduleStandard)
                {
                    db.Entry(ms).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(moduleStandard);
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
