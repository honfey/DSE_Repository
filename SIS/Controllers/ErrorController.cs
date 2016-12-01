using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SIS.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            return View("Error");
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 200;
            return View();

        }

        public ActionResult InternalServer()
        {
            Response.StatusCode = 200;
            return View();
        }

        public ActionResult Error1()
        {
            Response.StatusCode = 200;
            return View();
        }
    }
}