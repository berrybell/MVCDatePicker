using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace MVCDatePicker1.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            var dateFile = Server.MapPath("~/App_Data/date.txt");
            ViewBag.Result = "";

            if (System.IO.File.Exists(dateFile))
            {
                //ReadAllText implicitly closes the file, so we won't need to do that manually
                var date = System.IO.File.ReadAllText(dateFile);               

                if (date != "" && date != null)
                {
                    ViewBag.Result = "The date is " + date + ".";
                    System.IO.File.WriteAllText(dateFile, "");
                }
                else
                {
                    // Empty file.
                    ViewBag.Result = "There is no date yet.";
                }
            }
            else
            {
                // File does not exist.
                ViewBag.Result = "There is no date yet.";
            }
            return View();
        }

        [HttpPost]
        public JsonResult SendDate(string date)
        {
            List<string> data = new List<string>();
            data.Add("date=" + date);

            var dateFile = Server.MapPath("~/App_Data/date.txt");
            ViewBag.Result = "";

            System.IO.File.WriteAllText(@dateFile, date);
            ViewBag.Result = "Information saved.";

            return Json(new { data, result = "OK" });
        }
    }
}