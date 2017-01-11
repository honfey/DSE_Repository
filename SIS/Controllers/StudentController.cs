using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIS.Models;
using System.Data.Entity.Validation;

namespace SIS.Controllers
{
    public class StudentController : Controller
    {
        private SISEntities db = new SISEntities();

        List<SelectListItem> resultList = new List<SelectListItem>()
             {
                //new SelectListItem{ Text="---Select Grade---", Value = "" },
                new SelectListItem{ Text="A+", Value = "A+" },
                new SelectListItem{ Text="A", Value = "A" },
                new SelectListItem{ Text="A-", Value = "A-" },
                new SelectListItem{ Text="B+", Value = "B+" },
                new SelectListItem{ Text="B", Value = "B" },
                new SelectListItem{ Text="C+", Value = "C+" },
                new SelectListItem{ Text="C", Value = "C" },
                new SelectListItem{ Text="D", Value = "D" },
                new SelectListItem{ Text="E", Value = "E" },
                new SelectListItem{ Text="G", Value = "G" },
                new SelectListItem{ Text="TH", Value = "TH" }
    };

        List<SelectListItem> siblingGender = new List<SelectListItem>()
             {
                new SelectListItem{ Text="Male", Value = "Male" },
                new SelectListItem{ Text="Female", Value = "Female" },
    };

        // GET: Student
        public ActionResult Index(string Month, string Year, string SearchName)
        {
            if (!string.IsNullOrWhiteSpace(SearchName) && !string.IsNullOrWhiteSpace(Month) && !string.IsNullOrWhiteSpace(Year))
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var StudentName = db.Students.Where(x => x.Name.ToString().ToLower().Contains(SearchName) && x.Intake.Year.Year1.ToString().Contains(Year) && x.Intake.Month.Month1.ToString().Contains(Month));
                return View(StudentName);
            }
            else if (!string.IsNullOrWhiteSpace(Month) && !string.IsNullOrWhiteSpace(Year))
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var StudentName = db.Students.Where(x => x.Intake.Year.Year1.ToString().Contains(Year) && x.Intake.Month.Month1.ToString().Contains(Month));
                return View(StudentName);
            }
            else if (!string.IsNullOrWhiteSpace(Month) && !string.IsNullOrWhiteSpace(SearchName))
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var StudentName = db.Students.Where(x => x.Name.ToString().ToLower().Contains(SearchName) && x.Intake.Month.Month1.ToString().Contains(Month));
                return View(StudentName);
            }
            else if (!string.IsNullOrWhiteSpace(Year) && !string.IsNullOrWhiteSpace(SearchName))
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var StudentName = db.Students.Where(x => x.Name.ToString().ToLower().Contains(SearchName) && x.Intake.Year.Year1.ToString().Contains(Year));
                return View(StudentName);
            }
            else if (!string.IsNullOrWhiteSpace(Month))
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var StudentName = db.Students.Where(x => x.Intake.Month.Month1.ToString().Contains(Month));
                return View(StudentName);
            }
            else if (!string.IsNullOrWhiteSpace(Year))
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var StudentName = db.Students.Where(x => x.Intake.Year.Year1.ToString().Contains(Year));
                return View(StudentName);
            }
            else if (!string.IsNullOrWhiteSpace(SearchName))
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var StduentName = db.Students.Where(x => x.Name.ToString().ToLower().Contains(SearchName));
                return View(StduentName);
            }
            else
            {
                ViewBag.Year = new SelectList(db.Years, "Id", "Year1");
                ViewBag.Month = new SelectList(db.Months, "Id", "Month1");
                var students = db.Students.Include(s => s.Intake).Include(s => s.SPMResults);
                return View(students.ToList());
            }





        }






        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            //viewbag.state = new selectlist(db.)

            var course_intakeName = from c in db.Intakes
                                    join i in db.Courses on c.CourseCode equals i.CourseCode
                                    select new { c.Id, Name = i.CourseCode + "(" + c.Year.Year1 + "/" + c.Month.Month1 + ")" };

            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Name");
            ViewBag.IntakeId = new SelectList(course_intakeName, "Id", "Name");
            //ViewBag.SPMResultId = new SelectList(db.SPMResults, "Id", "Id");
            ViewBag.SPMResultList = new SelectList(resultList, "Value", "Text");

            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            var studentIntakeMonth = db.Intakes.Where(r => r.Id == student.IntakeId);

            int IntakeyearId = 0;
            int IntakemonthId = 0;
            foreach (var items in studentIntakeMonth.ToList())
            {
                IntakeyearId = items.YearId;
                IntakemonthId = items.MonthId;
            }

            var studentIntakeMonth2 = db.Months.Where(s => s.Id == IntakemonthId);
            var studentIntakeYear = db.Years.Where(t => t.Id == IntakeyearId);

            string Month = "";
            string Year = "";
            foreach (var items1 in studentIntakeMonth2.ToList())
            {
                Month = items1.Month1;
            }

            foreach (var items2 in studentIntakeYear.ToList())
            {
                Year = items2.Year1;
            }

            int ConvertYear = Convert.ToInt32(Year) - 2000;




            if (ModelState.IsValid)
            {              
 
                db.Students.Add(student);
                db.SaveChanges();
                student.StudentId = "P"  + ConvertYear + Month + student.Id.ToString("D4");
                db.SaveChanges();

                

                if (student.Addresses != null  && student.Addresses.Count() > 0)
                {             

                    foreach (var i in student.Addresses)
                    {
                        i.StudentId = student.Id;
                        db.Entry(i).State = EntityState.Modified;
                    }
                                        
                }

                if (student.SPMResults != null && student.SPMResults.Count() > 0)
                {

                    foreach (var i in student.SPMResults)
                    {
                        if (i.SubjectName != null && i.Grade != null)
                        {
                            i.StudentId = student.Id;
                            db.Entry(i).State = EntityState.Modified;
                        }                    
                    }

                }

                if (student.Siblings != null && student.Siblings.Count() > 0)
                {

                    foreach (var i in student.Siblings)
                    {
                        i.StudentId = student.Id;
                        db.Entry(i).State = EntityState.Modified;
                    }

                }

                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            Response.Write("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("Index");
            }

            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Name", student.NationalityId);
            ViewBag.IntakeId = new SelectList(db.Intakes, "Id", "CourseCode", student.IntakeId);
            //ViewBag.SPMResultId = new SelectList(db.SPMResults, "Id", "Id", student.SPMResultId);
            ViewBag.SPMResultList = new SelectList(resultList, "Value", "Text");
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            var course_intakeName = from c in db.Intakes
                                    join i in db.Courses on c.CourseCode equals i.CourseCode
                                    select new { c.Id, Name = i.CourseCode + "(" + c.Year.Year1 + "/" + c.Month.Month1 + ")" };

            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Name", student.NationalityId);
            ViewBag.IntakeId = new SelectList(course_intakeName, "Id", "Name", student.IntakeId);

            ViewBag.SiblingGender = new SelectList(siblingGender, "Value", "Text");
            ViewBag.SPMResultList = new SelectList(resultList, "Value", "Text");
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            
            if (ModelState.IsValid)
            {
                if (student.Siblings != null && student.Siblings.Count() > 0)
                {

                    foreach (var i in student.Siblings)
                    {
                        i.StudentId = student.Id;

                        if (i.Id == 0)
                        {
                            
                            db.Entry(i).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(i).State = EntityState.Modified; 
                        }
                    }

                    //db.Siblings.AddRange(student.Siblings);
                }


                if (student.Addresses != null && student.Addresses.Count() > 0)
                {

                    foreach (var i in student.Addresses)
                    {
                        i.StudentId = student.Id;

                        if (i.Id == 0)
                        {
                            db.Entry(i).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(i).State = EntityState.Modified;
                        }
                    }

                    //db.Addresses.AddRange(student.Addresses);
                }

                if (student.SPMResults != null && student.SPMResults.Count() > 0)
                {

                    foreach (var i in student.SPMResults)
                    {
                        i.StudentId = student.Id;

                        if (i.Id == 0)
                        {
                            db.Entry(i).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(i).State = EntityState.Modified;
                        }
                    }

                    //db.SPMResults.AddRange(student.SPMResults);
                }
               
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var course_intakeName = from c in db.Intakes
                                    join i in db.Courses on c.CourseCode equals i.CourseCode
                                    select new { c.Id, Name = i.CourseCode + "(" + c.Year.Year1 + "/" + c.Month.Month1 + ")" };

            ViewBag.NationalityId = new SelectList(db.Nationalities, "Id", "Name", student.NationalityId);
            ViewBag.IntakeId = new SelectList(course_intakeName, "Id", "Name", student.IntakeId);
            //ViewBag.SPMResultId = new SelectList(db.SPMResults, "Id", "Id", student.SPMResultId);

            ViewBag.SiblingGender = new SelectList(siblingGender, "Value", "Text");
            ViewBag.SPMResultList = new SelectList(resultList, "Value", "Text");

            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);

            var oldAddresses = db.Addresses.Where(x => x.StudentId == student.Id);
            if (oldAddresses != null && oldAddresses.Count() > 0)
                db.Addresses.RemoveRange(oldAddresses);

            var oldSPMResults = db.SPMResults.Where(x => x.StudentId == student.Id);
            if (oldSPMResults != null && oldSPMResults.Count() > 0)
                db.SPMResults.RemoveRange(oldSPMResults);

            var oldSiblings = db.Siblings.Where(x => x.StudentId == student.Id);
            if (oldSiblings != null && oldSiblings.Count() > 0)
                db.Siblings.RemoveRange(oldSiblings);

            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAddress(int id)
        {
            int rs = 0;
            Address i = db.Addresses.Find(id);
            db.Addresses.Remove(i);
            rs = db.SaveChanges();
            return Json(new { deletedRow = rs }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteSubject(int id)
        {
            int rs = 0;
            SPMResult i = db.SPMResults.Find(id);
            db.SPMResults.Remove(i);
            rs = db.SaveChanges();
            return Json(new { deletedRow = rs }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteSibling(int id)
        {
            int rs = 0;
            Sibling i = db.Siblings.Find(id);
            db.Siblings.Remove(i);
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
