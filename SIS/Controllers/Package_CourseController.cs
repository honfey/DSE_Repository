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
    public class Package_CourseController : Controller
    {
        private SISEntities db = new SISEntities();

        // GET: Package_Course
        //public ActionResult Index()
        //{
        //    var package_Course = db.Package_Course.Include(p => p.Course);
        //    return View(package_Course.ToList());
        //}

        public ActionResult Index(string SearchString)
        {
            if (!String.IsNullOrEmpty(SearchString))
            {
                var temp = db.Package_Course.OrderBy(i => i.Student.Name).Where(j => j.Student.Name.ToLower().Contains(SearchString.ToLower()));
                return View(temp);
            }
            var package_Course = db.Package_Course.Include(p => p.Course).Include(p => p.Student);
            return View(db.Package_Course);
        }

        // GET: Package_Course/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package_Course package_Course = db.Package_Course.Find(id);
            if (package_Course == null)
            {
                return HttpNotFound();
            }
            return View(package_Course);
        }

        // GET: Package_Course/Create
        public ActionResult Create()
        {
            ViewBag.CourseId = new SelectList(db.Courses, "CourseCode", "Name");
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name");

            return View();
        }

        // POST: Package_Course/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CourseId,StudentId,TotalPrice,FirstPay,MonthlyInterest,InterestRate,MonthlyPayment")] Package_Course package_Course)
        {
            if (ModelState.IsValid)
            {

                if (package_Course.MonthlyInterest == 0 || package_Course.MonthlyInterest == null)
                {
                    package_Course.InterestRate = 0;
                    package_Course.MonthlyPayment = package_Course.TotalPrice - package_Course.FirstPay;
                }
                else if (package_Course.InterestRate == 0 || package_Course.InterestRate == null)
                {
                    package_Course.MonthlyPayment = (package_Course.TotalPrice - package_Course.FirstPay) / package_Course.MonthlyInterest;
                }
                else
                {
                    package_Course.MonthlyPayment = ((package_Course.TotalPrice / 100 * Convert.ToDecimal(package_Course.InterestRate)) - package_Course.FirstPay) / Convert.ToDecimal(package_Course.MonthlyInterest);
                }

                db.Package_Course.Add(package_Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", package_Course.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", package_Course.StudentId);
            return View(package_Course);
        }

        // GET: Package_Course/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package_Course package_Course = db.Package_Course.Find(id);
            if (package_Course == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseId = new SelectList(db.Courses, "CourseCode", "Name", package_Course.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", package_Course.StudentId);

            return View(package_Course);
        }

        // POST: Package_Course/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CourseId,StudentId,TotalPrice,FirstPay,MonthlyInterest,InterestRate,MonthlyPayment")] Package_Course package_Course)
        {
            if (ModelState.IsValid)
            {

                if (package_Course.MonthlyInterest == 0 || package_Course.MonthlyInterest == null)
                {
                    package_Course.InterestRate = 0;
                    package_Course.MonthlyPayment = package_Course.TotalPrice - package_Course.FirstPay;
                }
                else if (package_Course.InterestRate == 0 || package_Course.InterestRate == null)
                {
                    package_Course.MonthlyPayment = (package_Course.TotalPrice - package_Course.FirstPay) / package_Course.MonthlyInterest;
                }
                else
                {
                    package_Course.MonthlyPayment = ((package_Course.TotalPrice / 100 * Convert.ToDecimal(package_Course.InterestRate)) - package_Course.FirstPay) / Convert.ToDecimal(package_Course.MonthlyInterest);
                }

                db.Package_Course.Add(package_Course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Name", package_Course.CourseId);
            ViewBag.StudentId = new SelectList(db.Students, "ID", "Name", package_Course.StudentId);
            return View(package_Course);
        }

        // GET: Package_Course/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Package_Course package_Course = db.Package_Course.Find(id);
            if (package_Course == null)
            {
                return HttpNotFound();
            }
            return View(package_Course);
        }

        // POST: Package_Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Package_Course package_Course = db.Package_Course.Find(id);
            db.Package_Course.Remove(package_Course);
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
