using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SIS.Models;


namespace SIS.Controllers
{
    [Authorize(Roles = "Admin, Trainer")]
    public class AttendancesController : Controller
    {
        private SISEntities db = new SISEntities();

        //Attendance related Database

        public ActionResult MarkAttendance(Attendance att, int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.ReturnTodayDate = DateTime.Now.ToShortDateString();
                var getClassStudentID = db.ClassStudents.Where(x => x.Course_ModuleId == id && x.CreateDate == id3 && x.Status == id2);
                DateTime? TodayDate = DateTime.Now.Date;
                var list = new List<Attendance>();



                foreach (var item in getClassStudentID.ToList())
                {
                    int ClassId = Convert.ToInt32(item.Id);

                    if (db.Attendances.Any(x => x.ClassStudentId == ClassId && x.TodayDate == TodayDate && x.Status == true))
                    {

                    }
                    else
                    {
                        att.ClassStudentId = ClassId;
                        att.TodayDate = DateTime.Now.Date;
                        att.Status = true;
                        att.EditBy = User.Identity.Name;
                        att.EditDate = DateTime.Now;
                        db.Attendances.Add(att);
                        db.SaveChanges();
                    }
                }

                foreach (var items in getClassStudentID.ToList())
                {
                    int ClassIDs = Convert.ToInt32(items.Id);

                    var TodayAttendance = db.Attendances.Where(x => x.ClassStudentId == ClassIDs && x.TodayDate == TodayDate && x.Status == true);
                    list.AddRange(TodayAttendance);

                }
                return View(list);
            }
            
        }

        [HttpPost]
        public ActionResult MarkAttendance(List<Attendance> att)
        {
            
            if (ModelState.IsValid)
            {
                foreach (var j in att)
                    {
                    if (j.MorningIn != null)
                    {
                        if (j.MorningIn.Value.Hours == 9)
                        {
                            if (j.MorningIn.Value.Minutes > 30)
                            {
                                j.MStatus = "Late";
                            }
                            else if (j.MorningIn.Value.Minutes <= 30)
                            {
                                j.MStatus = "Ontime";
                            }
                        }
                        else if (j.MorningIn.Value.Hours > 9)
                        {
                            j.MStatus = "Late";
                        }
                        else if (j.MorningIn.Value.Hours < 9)
                        {
                            j.MStatus = "Ontime";
                        }
                    }
                    else
                    {
                        j.MStatus = "Absent";
                    }

                    if (j.AfternoonIn != null)
                    {
                        if (j.AfternoonIn.Value.Hours == j.MorningOut.Value.Hours + 1)
                        {
                            if (j.AfternoonIn.Value.Minutes > j.MorningOut.Value.Minutes)
                            {
                                j.AStatus = "Late";
                            }
                            else if (j.AfternoonIn.Value.Minutes <= j.MorningOut.Value.Minutes)
                            {
                                j.AStatus = "Ontime";
                            }
                        }
                        else if (j.AfternoonIn.Value.Hours < j.MorningOut.Value.Hours + 1)
                        {
                            j.AStatus = "Ontime";
                        }
                        else if (j.AfternoonIn.Value.Hours > j.MorningOut.Value.Hours + 1)
                        {
                            j.AStatus = "Late";
                        }
                    }
                    else
                    {
                        if (DateTime.Now.Hour < 13)
                        {
                            j.AStatus = null;
                        }
                        else if (DateTime.Now.Hour == 13)
                        {
                            if (DateTime.Now.Minute <= 15)
                            {
                                j.AStatus = null;
                            }
                            else if (DateTime.Now.Minute > 15)
                            {
                                j.AStatus = "Absent";
                            }
                        }
                        else if (DateTime.Now.Hour > 13)
                        {
                            j.AStatus = "Absent";
                        }
                    }
                    j.EditDate = DateTime.Now;
                    j.Status = true;
                    j.EditBy = User.Identity.Name;

                    db.Entry(j).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("ClassAvailable");
            }
            return View(att);
        }

        public ActionResult EditDate(DateTime Date, int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                ViewBag.ReturnDate = Date.ToShortDateString();
                var SelectClassStudentID = db.ClassStudents.Where(a => a.Course_ModuleId == id && a.CreateDate == id3 && a.Status == id2);
                var lists = new List<Attendance>();
                foreach (var item in SelectClassStudentID.ToList())
                {
                    var Select = db.Attendances.Where(a => a.TodayDate == Date && a.ClassStudentId == item.Id && a.Status == true);
                    lists.AddRange(Select);
                }

                return View(lists);
            }

        }

        [HttpPost]
        public ActionResult EditDate(List<Attendance> att)
        {
            if (ModelState.IsValid)
            {
                foreach (var j in att)
                {
                    if (j.MorningIn != null)
                    {
                        if (j.MorningIn.Value.Hours == 9)
                        {
                            if (j.MorningIn.Value.Minutes > 30)
                            {
                                j.MStatus = "Late";
                            }
                            else if (j.MorningIn.Value.Minutes <= 30)
                            {
                                j.MStatus = "Ontime";
                            }
                        }
                        else if (j.MorningIn.Value.Hours > 9)
                        {
                            j.MStatus = "Late";
                        }
                        else if (j.MorningIn.Value.Hours < 9)
                        {
                            j.MStatus = "Ontime";
                        }
                    }
                    else
                    {
                        j.MStatus = "Absent";
                    }

                    if (j.AfternoonIn != null)
                    {
                        if (j.AfternoonIn.Value.Hours == j.MorningOut.Value.Hours + 1)
                        {
                            if (j.AfternoonIn.Value.Minutes > j.MorningOut.Value.Minutes)
                            {
                                j.AStatus = "Late";
                            }
                            else if (j.AfternoonIn.Value.Minutes <= j.MorningOut.Value.Minutes)
                            {
                                j.AStatus = "Ontime";
                            }
                        }
                        else if (j.AfternoonIn.Value.Hours < j.MorningOut.Value.Hours + 1)
                        {
                            j.AStatus = "Ontime";
                        }
                        else if (j.AfternoonIn.Value.Hours > j.MorningOut.Value.Hours + 1)
                        {
                            j.AStatus = "Late";
                        }
                    }
                    else
                    {
                        j.AStatus = "Absent";
                    }

                    j.Status = true;
                    j.EditBy = User.Identity.Name;
                    j.EditDate = DateTime.Now;

                    db.Entry(j).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("ClassAvailable");
            }
            return View(att);
        }

        public ActionResult MarkBack(Attendance att, int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var getClassStudentID = db.ClassStudents.Where(x => x.Course_ModuleId == id && x.CreateDate == id3 && x.Status == id2);
                DateTime? TodayDate = DateTime.Now.Date;
                var list = new List<Attendance>();



                foreach (var item in getClassStudentID.ToList())
                {
                    int ClassId = Convert.ToInt32(item.Id);

                    if (db.Attendances.Any(x => x.ClassStudentId == ClassId && x.TodayDate == null && x.Status == null))
                    {

                    }
                    else
                    {
                        att.EditBy = User.Identity.Name;
                        att.EditDate = DateTime.Now;
                        att.ClassStudentId = ClassId;
                        db.Attendances.Add(att);
                        db.SaveChanges();
                    }

                }

                foreach (var items in getClassStudentID.ToList())
                {
                    int ClassIDs = Convert.ToInt32(items.Id);
                    // must all null
                    var TodayAttendance = db.Attendances.Where(x => x.ClassStudentId == ClassIDs && x.TodayDate == null && x.Status == null);
                    list.AddRange(TodayAttendance);

                }
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult MarkBack(List<Attendance> att)
        {
            var FirstTodayDate = att.ElementAtOrDefault(0).TodayDate;

            if (ModelState.IsValid)
            {
                foreach (var j in att)
                {

                    var gotTodayDate = db.Attendances.Any(b => b.ClassStudentId == j.ClassStudentId && b.TodayDate == FirstTodayDate);
                    if (gotTodayDate)
                    {
                        break;
                    }
                    else
                    {
                        if (j.MorningIn != null)
                        {
                            if (j.MorningIn.Value.Hours == 9)
                            {
                                if (j.MorningIn.Value.Minutes > 30)
                                {
                                    j.MStatus = "Late";
                                }
                                else if (j.MorningIn.Value.Minutes <= 30)
                                {
                                    j.MStatus = "Ontime";
                                }
                            }
                            else if (j.MorningIn.Value.Hours > 9)
                            {
                                j.MStatus = "Late";
                            }
                            else if (j.MorningIn.Value.Hours < 9)
                            {
                                j.MStatus = "Ontime";
                            }
                        }
                        else
                        {
                            j.MStatus = "Absent";
                        }

                        if (j.AfternoonIn != null)
                        {
                            if (j.AfternoonIn.Value.Hours == j.MorningOut.Value.Hours + 1)
                            {
                                if (j.AfternoonIn.Value.Minutes > j.MorningOut.Value.Minutes)
                                {
                                    j.AStatus = "Late";
                                }
                                else if (j.AfternoonIn.Value.Minutes <= j.MorningOut.Value.Minutes)
                                {
                                    j.AStatus = "Ontime";
                                }
                            }
                            else if (j.AfternoonIn.Value.Hours < j.MorningOut.Value.Hours + 1)
                            {
                                j.AStatus = "Ontime";
                            }
                            else if (j.AfternoonIn.Value.Hours > j.MorningOut.Value.Hours + 1)
                            {
                                j.AStatus = "Late";
                            }
                        }
                        else
                        {
                            j.AStatus = "Absent";
                        }
                        j.TodayDate = att.ElementAtOrDefault(0).TodayDate;

                    }
                    j.EditDate = DateTime.Now;
                    j.Status = true;
                    j.EditBy = User.Identity.Name;



                    db.Entry(j).State = EntityState.Modified;
                }
                db.SaveChanges();
                return RedirectToAction("ClassAvailable");
            }
            return View(att);
        }

        public ActionResult DeleteConfirmed(List<Attendance> att, int? id, DateTime Date, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var select = db.ClassStudents.Where(a => a.Course_ModuleId == id && a.CreateDate == id3 && a.Status == id2);
                var list = new List<Attendance>();
                foreach (var item in select.ToList())
                {
                    var finding = db.Attendances.Single(a => a.ClassStudentId == item.Id && a.TodayDate == Date && a.Status == true);
                    //db.Attendances.Remove(finding);
                    finding.Status = false;
                    finding.EditBy = User.Identity.Name;
                    finding.EditDate = DateTime.Now;

                    db.Entry(finding).State = EntityState.Modified;
                }


                db.SaveChanges();
                return RedirectToAction("ClassAvailable");
            }
        }

        //Check Attendance

        public ActionResult CheckAttendance(int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var haha = db.Attendances.OrderBy(x => x.TodayDate).Where(a => a.ClassStudent.Course_ModuleId == id  && a.ClassStudent.CreateDate == id3 && a.ClassStudent.Status == id2 && a.TodayDate != null && a.Status == true).Select(x => x.TodayDate).Distinct().ToList();

                var count1 = haha.Count();

                ViewData["DateList"] = haha;                

                if (id > 0)
                {

                    var resultStudentID = db.Attendances.OrderBy(x => x.ClassStudent.Student.Name).ThenBy(x => x.TodayDate).Where(a => a.ClassStudent.Course_ModuleId == id && a.ClassStudent.Status == id2 && a.ClassStudent.CreateDate == id3 && a.Status == true);

                    int count = resultStudentID.Count();

                    return View(resultStudentID);
                }
                else
                {
                    return View(new List<Attendance>());
                }
            }

        }

        public ActionResult CheckIndividualAttendance(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var haha = db.Attendances.OrderBy(x => x.TodayDate).Where(a => a.ClassStudentId == id && a.TodayDate != null && a.Status == true).Select(x => x.TodayDate).Distinct().ToList();
                ViewData["DateList"] = haha;

                if (id > 0)
                {
                    var resultStudentID = db.Attendances.OrderBy(x => x.ClassStudent.Student.Name).ThenBy(x => x.TodayDate).Where(a => a.ClassStudentId == id && a.Status == true);
                    return View(resultStudentID);

                }
                else
                {
                    return View(new List<Attendance>());
                }
            }
        }

        //Choises

        public ActionResult ClassAvailable(int? Search)
        {
            //ViewBag.Status = new SelectList(db.Course_Module, "Id", "Status").Distinct();
            //ViewBag.TrueFalse = (from r in db.Course_Module
            //                select r.Status != null).Distinct().ToList();

            if (Search == null)
            {
                var course_Module = db.ClassStudents.Where(x => x.Status == true);
                return View(course_Module.ToList());
            }
            else
            {
                var convert = Convert.ToBoolean(Search);
                var resultName = db.ClassStudents.Where(x => x.Status == convert);
                return View(resultName.ToList());
            }
        }

        public ActionResult CheckChoise(int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var Example = db.ClassStudents.Where(a => a.Course_ModuleId == id && a.CreateDate == id3 && a.Status == id2);
                return View(Example);
            }
        }

        public ActionResult CheckIndividual(int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var classStudent = db.ClassStudents.Where(c => c.Course_ModuleId == id && c.Status == id2 && c.CreateDate == id3);
                return View(classStudent);
            }
        }        

        public ActionResult ChooseDate(int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var getdata = db.ClassStudents.Where(a => a.CreateDate == id3 && a.Course_ModuleId == id && a.Status == id2);
                var attendance = db.Attendances.OrderBy(x => x.TodayDate).Where(a => a.ClassStudent.Course_ModuleId == id && a.ClassStudent.Status == id2 && a.ClassStudent.CreateDate == id3 && a.TodayDate != null && a.Status == true).Select(x => x.TodayDate).Distinct().ToList();
                ViewData["DateList"] = attendance;
                return View(getdata);
            }
        }

        public ActionResult ChooseDateDelete(int? id, bool id2, DateTime id3)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var getdata = db.ClassStudents.Where(a => a.CreateDate == id3 && a.Course_ModuleId == id && a.Status == id2);
                var attendance = db.Attendances.OrderBy(x => x.TodayDate).Where(a => a.ClassStudent.Course_ModuleId == id && a.ClassStudent.CreateDate == id3 && a.ClassStudent.Status == id2 && a.TodayDate != null && a.Status == true).Select(x => x.TodayDate).Distinct().ToList();
                ViewData["DateList"] = attendance;
                return View(getdata);
            }
        }

        //CSSM
        public ActionResult CSS(string SearchIC, string SearchID, string SearchName)
        {
            if (!string.IsNullOrEmpty(SearchIC) && !string.IsNullOrEmpty(SearchID) && !string.IsNullOrEmpty(SearchName))
            {
                var studentName = db.Students.Where(x => x.IC.ToString().Contains(SearchIC) && x.StudentId.ToString().Contains(SearchID) && x.Name.Contains(SearchName));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchIC) && !string.IsNullOrEmpty(SearchID))
            {

                var studentName = db.Students.Where(x => x.IC.ToString().Contains(SearchIC) && x.StudentId.ToString().Contains(SearchID));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchID) && !string.IsNullOrEmpty(SearchName))
            {
                var studentName = db.Students.Where(x => x.Name.Contains(SearchName) && x.StudentId.ToString().Contains(SearchID));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchName) && !string.IsNullOrEmpty(SearchIC))
            {

                var studentName = db.Students.Where(x => x.Name.Contains(SearchName) && x.IC.ToString().Contains(SearchIC));
                return View(studentName);
            }
            else if (!string.IsNullOrEmpty(SearchIC))
            {
                var studentIC = db.Students.Where(x => x.IC.ToString().Contains(SearchIC));
                return View(studentIC);
            }
            else if (!string.IsNullOrEmpty(SearchID))
            {
                var studentId = db.Students.Where(x => x.StudentId.ToString().Contains(SearchID));
                return View(studentId);
            }
            else if (!string.IsNullOrEmpty(SearchName))
            {
                var studentName = db.Students.Where(x => x.Name.Contains(SearchName));
                return View(studentName);
            }
            else
            {
                return View(new List<Student>());
            }



        }

        public ActionResult CSSM(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var module = db.ClassStudents.Where(x => x.StudentId == id);
                return View(module);
            }
        }








        //Useless
        public ActionResult Delete(List<Attendance> att, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }
        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId");
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassStudentId,MorningIn,MorningOut,AfternoonIn,AfternoonOut")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Attendances.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId", attendance.ClassStudentId);
            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.Attendances.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId", attendance.ClassStudentId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassStudentId,MorningIn,MorningOut,AfternoonIn,AfternoonOut")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassStudentId = new SelectList(db.ClassStudents, "ClassStudentId", "ClassStudentId", attendance.ClassStudentId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]    

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
