using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIS.Models;
using System.Web.Configuration;
using System.IO;
using System.Web.Hosting;

namespace SIS.Controllers
{
    public class ImagesController : Controller
    {
        private SISEntities db = new SISEntities();
        private string webConfigPath = "~/" + WebConfigurationManager.AppSettings["UploadImage"];
        private string webConfigPath2 = "~/" + WebConfigurationManager.AppSettings["UploadLab"];

        // GET: Images
        public ActionResult Index()
        {
            return View(db.Images.ToList());
        }

        // GET: Images/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        // GET: Images/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(List<HttpPostedFileBase> images)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        List<Image> imgs = new List<Image>();
        //        foreach (var obj in images)
        //        {
        //            if (obj.ContentLength != 0 && obj.FileName != "")
        //            {
        //                string fDate = string.Format("{0:yyyyMMddhhmmsstt}", DateTime.Now);
        //                string documentName = obj.FileName.Trim().Replace(" ", "_");
        //                string pathToSave = Server.MapPath(webConfigPath);
        //                string filename = fDate + '_' + documentName;
        //                obj.SaveAs(Path.Combine(pathToSave, filename));

        //                imgs.Add(new Image { FileName = filename });
        //            }
        //        }
        //        db.Images.AddRange(imgs);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View("Create");
        //}

        public ActionResult UploadLab(int id)
        {
            return View();
        }

        // POST: Images/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadLab(List<HttpPostedFileBase> Lab,int id)
        {
            if (ModelState.IsValid)
            {
                List<Image> lb = new List<Image>();
                foreach (var obj in Lab)
                {
                    if (obj.ContentLength != 0 && obj.FileName != "")
                    {
                        string fDate = string.Format("{0:yyyyMMddhhmmsstt}", DateTime.Now);
                        string documentName = obj.FileName.Trim().Replace(" ", "_");

                        var cw1 = db.CourseWorks.Find(id);
                        string studentId = cw1.ClassStudent.Student.StudentId;
                        string labName = cw1.ModuleStandard.LabName;
                        string module = cw1.ClassStudent.Course_Module.Module.ModuleCode;

                        string pathToSave = Server.MapPath(webConfigPath2);
                        string filename = fDate + '_' + studentId + '_' + labName + '_' + module + '_' + documentName;
                        obj.SaveAs(Path.Combine(pathToSave, filename));

                        lb.Add(new Image { FileName = filename });
                    }
                }
                db.Images.AddRange(lb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("UploadLab");
        }

        //download Lab
        public ActionResult DownloadLab(string filename)
        {
            return File(webConfigPath2 + filename, GetContentType(filename), Server.UrlEncode(filename));
        }

        private string GetContentType(string fileName)
        {
            string contentType = "application/octetstream";

            string ext = System.IO.Path.GetExtension(fileName).ToLower();

            Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);

            if (registryKey != null && registryKey.GetValue("Content Type") != null)
                contentType = registryKey.GetValue("Content Type").ToString();

            return contentType;
        }

        public ActionResult DeleteLab(string lab, int id)
        {
            string pathToSave = HostingEnvironment.MapPath("~") + WebConfigurationManager.AppSettings["UploadLab"];
            string fullPath = pathToSave + lab;
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
                Image i = db.Images.Find(id);
                i.FileName = null;
                db.Images.Remove(i);
                db.SaveChanges();

                TempData["Success"] = "You have successfully deleted an image.";
            }
            return RedirectToAction("Index");
        }

        //// GET: Images/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Image image = db.Images.Find(id);
        //    if (image == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(image);
        //}

        //// POST: Images/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FileName")] Image image)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(image).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(image);
        //}

        //// GET: Images/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Image image = db.Images.Find(id);
        //    if (image == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(image);
        //}

        //// POST: Images/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Image image = db.Images.Find(id);
        //    db.Images.Remove(image);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}



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
