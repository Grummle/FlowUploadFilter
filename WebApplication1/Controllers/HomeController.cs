using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices.Internal;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using FlowUploadFilter;
using WebGrease.Css.Extensions;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Upload()
        {
            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [FlowUpload("pdf","txt")]
        [ActionName("Upload")]
        public ActionResult Upload(FlowFile file)
        {
            return Json(new {derp=file.flowFilename});
        }



    }
}