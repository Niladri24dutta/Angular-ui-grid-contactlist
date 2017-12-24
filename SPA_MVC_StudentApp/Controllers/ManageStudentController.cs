using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SPA_MVC_StudentApp.Controllers
{
    public class ManageStudentController : Controller
    {
        //
        // GET: /ManageStudent/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddStudent()
        {
            return PartialView("AddStudent");
        }

        public ActionResult EditStudent()
        {
            return PartialView("EditStudent");
        }

        public ActionResult ShowAllStudent()
        {
            return PartialView("ShowAllStudent");
        }

        public ActionResult DeleteStudent()
        {
            return PartialView("DeleteStudent");
        }


	}
}