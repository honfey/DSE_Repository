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
    public class MarkTypesController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: MarkTypes
        public ActionResult Index()
        {
            return View(db.MarkTypes.ToList());
        }

        // GET: MarkTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkType markType = db.MarkTypes.Find(id);
            if (markType == null)
            {
                return HttpNotFound();
            }
            return View(markType);
        }

        // GET: MarkTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarkTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] MarkType markType)
        {
            if (ModelState.IsValid)
            {
                db.MarkTypes.Add(markType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(markType);
        }

        // GET: MarkTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkType markType = db.MarkTypes.Find(id);
            if (markType == null)
            {
                return HttpNotFound();
            }
            return View(markType);
        }

        // POST: MarkTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] MarkType markType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(markType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(markType);
        }

        // GET: MarkTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkType markType = db.MarkTypes.Find(id);
            if (markType == null)
            {
                return HttpNotFound();
            }
            return View(markType);
        }

        // POST: MarkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarkType markType = db.MarkTypes.Find(id);
            db.MarkTypes.Remove(markType);
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
