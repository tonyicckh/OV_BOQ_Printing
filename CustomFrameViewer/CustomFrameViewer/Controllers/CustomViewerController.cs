using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomFrameViewer.Controllers
{
    public class CustomViewerController : Controller
    {
        // GET: CustomViewer
        public ActionResult FrameViewer()
        {
            return View();
        }
    }
}