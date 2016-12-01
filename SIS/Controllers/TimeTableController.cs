using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS.Controllers
{
    public class TimeTableController : Controller
    {
        // GET: TimeTable
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Table()
        {
            return View();
        }

        // GET: TimeTable/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TimeTable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeTable/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeTable/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TimeTable/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TimeTable/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TimeTable/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
