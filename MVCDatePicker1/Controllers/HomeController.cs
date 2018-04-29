using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDatePicker1.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SendDate(string date)
        {
            List<string> data = new List<string>();
            data.Add("date=" + date);
            return Json(new { data, result = "OK" });
        }
    }
}