using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using SIS.Models;

namespace SIS.Controllers
{
    public class TrainersController : Controller
    {
        private SISEntities db = new SISEntities();
        private string webConfigPath = "~/" + WebConfigurationManager.AppSettings["UploadImage"];

        // GET: Trainers
        public ActionResult Index()
        {
            return View(db.Trainers.ToList());
        }

        // GET: Trainers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // GET: Trainers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trainers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IC,Name,FirstName,LastName,Email,PhoneNum,Address1,Address2,Postcode,City,State,Country,Gender,Race,DateOfBirth,FileName")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                //List<Image> imgs = new List<Image>();
                //foreach (var obj in Image)
                //{
                //    if (obj.ContentLength != 0 && obj.FileName != "")
                //    {
                //        string fDate = string.Format("{0:yyyyMMddhhmmsstt}", DateTime.Now);
                //        string documentName = obj.FileName.Trim().Replace(" ", "_");
                //        string pathToSave = Server.MapPath("~/Content/UploadedFiles/TrainerPhoto");
                //        string filename = fDate + '_' + documentName;
                //        obj.SaveAs(Path.Combine(pathToSave, filename));

                //        imgs.Add(new Image { FileName = filename });
                //    }
                //}
                db.Trainers.Add(trainer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trainer);
        }

        // GET: Trainers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IC,Name,FirstName,LastName,Email,PhoneNum,Address1,Address2,Postcode,City,State,Country,Gender,Race,DateOfBirth,FileName")] Trainer trainer)
        {
            if (ModelState.IsValid)
            {
                //HttpPostedFileBase obj = Request.Files["Filename"];
                //if (obj != null && obj.ContentLength != 0 && obj.FileName != "")
                //{
                //    string fDate = string.Format("{0:yyyyMMddhhmmsstt}", DateTime.Now);
                //    string documentName = obj.FileName.Trim().Replace(" ", "_");

                //    string fullPath = trainer.FilePath + trainer.Filename;
                //    if (System.IO.File.Exists(fullPath))
                //    {
                //        System.IO.File.Delete(fullPath);
                //    }

                //    string filename = fDate + '_' + documentName;
                //    obj.SaveAs(Path.Combine(trainer.FilePath, filename));
                //    trainer.Filename = filename;
                //}
                db.Entry(trainer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trainer);
        }

        // GET: Trainers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trainer trainer = db.Trainers.Find(id);
            if (trainer == null)
            {
                return HttpNotFound();
            }
            return View(trainer);
        }

        // POST: Trainers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trainer trainer = db.Trainers.Find(id);
            db.Trainers.Remove(trainer);
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
