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

        //// GET: CourseWorks/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id");
        //    ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId");
        //    ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName");
        //    ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name");
        //    return View();
        //}

        //// POST: CourseWorks/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ClassStudentId,Course_ModuleId,TestTypeId,ModuleStandardId,Marks")] CourseWork courseWork)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CourseWorks.Add(courseWork);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
        //    ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", courseWork.Course_ModuleId);
        //    ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", courseWork.ModuleStandardId);
        //    ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name", courseWork.TestTypeId);
        //    return View(courseWork);
        //}

        //// GET: CourseWorks/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CourseWork courseWork = db.CourseWorks.Find(id);
        //    if (courseWork == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
        //    ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", courseWork.Course_ModuleId);
        //    ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", courseWork.ModuleStandardId);
        //    ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name", courseWork.TestTypeId);
        //    return View(courseWork);
        //}

        //// POST: CourseWorks/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,ClassStudentId,Course_ModuleId,TestTypeId,ModuleStandardId,Marks")] CourseWork courseWork)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(courseWork).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "Id", "Id", courseWork.ClassStudentId);
        //    ViewBag.Course_ModuleId = new SelectList(db.Course_Module, "Id", "CourseId", courseWork.Course_ModuleId);
        //    ViewBag.ModuleStandardId = new SelectList(db.ModuleStandards, "Id", "LabName", courseWork.ModuleStandardId);
        //    ViewBag.TestTypeId = new SelectList(db.TestTypes, "Id", "Name", courseWork.TestTypeId);
        //    return View(courseWork);
        //}

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

        public ActionResult ShowClass(int? Search)
        {          
            if(Search == null)
            {
                var standard = db.ClassStudents.OrderBy(x => x.Course_ModuleId).Where(x => x.Status == true);
                return View(standard.ToList());
            }else
            {
                var convert = Convert.ToBoolean(Search);
                var resultName = db.ClassStudents.OrderBy(x => x.Course_ModuleId).Where(x => x.Status == convert);
                return View(resultName.ToList());
            }
            
        }

        public ActionResult ShowStudent(int id)
        {
            var ClassStudent = db.ClassStudents.Where(x => x.Course_ModuleId == id);
            var c = db.Course_Module.Find(id).Module.Name;
            var d = db.Course_Module.Find(id).Module.ModuleCode;
            ViewData["ModuleName"] = c + "(" + d + ")";

            return View(ClassStudent.ToList());
        }

      
        public ActionResult ReportCard(int? id)
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

        //[Authorize]
        public ActionResult MarkMarks(CourseWork cw1, int id, int id2, int? TT)
        {
            var studentName = db.ClassStudents.Find(id).Student.Name;
            ViewData["StudentName"] = studentName;

            var standard = db.ModuleStandards.Where(x => x.Course_ModuleId == id2);
            foreach (var item in standard)
            {
                string itemID = Convert.ToString(item.Id);
                ViewData[itemID] = item.Marks;

                var moduleName = item.Course_Module.Module.Name;
                var moduleCode = item.Course_Module.Module.ModuleCode;
                ViewData["ModuleName"] = moduleName + "(" + moduleCode + ")";
            }

            ViewBag.TT = new SelectList(db.TestTypes, "Id", "Name");
            var checkCount = db.ModuleStandards.Where(q => q.Course_ModuleId == id2); //5 count
            var listCourseWork = new List<CourseWork>();


            if (TT == null)
            {
                for (int q = 1; q <= db.TestTypes.Count(); q++)
                {
                    var checking = db.CourseWorks.Any(x => x.ClassStudentId == id && x.Course_ModuleId == id2 && x.TestTypeId == q);                   
                    if (checking)
                    {
                       
                    }
                    else
                    {
                        foreach (var item in checkCount.ToList())
                        {
                            cw1.ClassStudentId = id;
                            cw1.Course_ModuleId = id2;
                            cw1.TestTypeId = q;
                            cw1.ModuleStandardId = item.Id;
                            db.CourseWorks.Add(cw1);
                            db.SaveChanges();
                        };
                    }
                }
                foreach (var item2 in checkCount.ToList())
                {
                    var show = db.CourseWorks.Where(a => a.ClassStudentId == id && a.Course_ModuleId == id2 && a.ModuleStandardId == item2.Id);
                    listCourseWork.AddRange(show);
                }
                var z = listCourseWork.Where(x => x.TestTypeId == 1);
                return View(z.ToList());
            }
            else
            {
                foreach (var item2 in checkCount.ToList())
                {
                    var show = db.CourseWorks.Where(a => a.ClassStudentId == id && a.Course_ModuleId == id2 && a.ModuleStandardId == item2.Id);
                    listCourseWork.AddRange(show);
                }
                var z = listCourseWork.Where(x => x.TestTypeId == TT);
                return View(z.ToList());
            }
        }


        [HttpPost]
        public ActionResult MarkMarks(List<CourseWork> courseWork,int id,int? id2)
        {
            if (ModelState.IsValid)
            {

                var total = (int?)0;
                var listcw = new List<CourseWork>();

                foreach (var cw in courseWork)
                {
                    if (cw.TestTypeId == 1)
                    {
                        total += cw.Marks;
                        cw.Total1 = total;
                        db.Entry(cw).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    if (cw.TestTypeId == 2)
                    {
                        total += cw.Marks;
                        cw.Total2 = total;
                        db.Entry(cw).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                    if (cw.TestTypeId == 3)
                    {
                        total += cw.Marks;
                        cw.Total3 = total;
                        db.Entry(cw).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }


                var status = db.ModuleStandards.Where(x => x.Course_ModuleId == id2);
                foreach (var item in status)
                {
                    foreach (var cw1 in courseWork)
                    {
                        if (cw1.Marks < item.Marks / 2)
                        {
                            cw1.Status = "Fail";
                            db.Entry(item).State = EntityState.Modified;
                                                      
                        }
                        else if (cw1.Marks >= item.Marks / 2)
                        {
                            cw1.Status = "Pass";
                            db.Entry(item).State = EntityState.Modified;
                        }
                    }
                }

               
                foreach (var item in courseWork)
                {
                    if(courseWork.Any(x=>x.Status == "Fail"))
                    {
                        var ttid = item.TestTypeId;
                        if (item.Status == "Pass" && item.TestTypeId == ttid)
                        {
                            var mt = item.ModuleStandardId;

                            var nxt = db.CourseWorks.Where(x => x.ModuleStandardId == mt && x.TestTypeId == ttid + 1 && x.ClassStudentId == id);
                            foreach (var item1 in nxt)
                            {
                                item1.Marks = item.Marks;
                                item1.Status = item.Status;
                            }
                        }
                    }
                    
                }
                db.SaveChanges();
                return RedirectToAction("ShowClass");
            }
            return View(courseWork);
        }

        //For Student 
        public ActionResult Check(int id, int id2,int ?TT)
        {
            var studentName = db.ClassStudents.Find(id).Student.Name;
            ViewData["StudentName"] = studentName;

            var moduleName = db.Course_Module.Find(id2).Module.Name;
            var moduleCode = db.Course_Module.Find(id2).Module.ModuleCode;
            ViewData["ModuleName"] = moduleName + "(" + moduleCode + ")";

            ViewBag.TT = new SelectList(db.TestTypes, "Id", "Name");
            
            if(TT == null)
            {
                var student = db.CourseWorks.Where(x => x.ClassStudentId == id && x.Course_ModuleId == id2 && x.TestTypeId == 1);
                return View(student.ToList());
            }else
            {
                var student = db.CourseWorks.Where(x => x.ClassStudentId == id && x.Course_ModuleId == id2 && x.TestTypeId == TT);
                return View(student.ToList());
            }
          
        }

        public ActionResult PassToMS()
        {
            return RedirectToRoute(new { controller = "ModuleStandards", action = "ShowStandard" });
        }

        public ActionResult PassToImage(int id)
        {
            return RedirectToRoute(new { controller = "Images", action = "UploadLab" , id = id  });
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
