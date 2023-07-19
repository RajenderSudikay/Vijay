using Sitecore.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Sitecore.Shell.UserOptions.HtmlEditor;

namespace MedProSC.Project.Website.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult Header()
        {
            return View("~/Views/Shared/Header.cshtml");
        }
    }
}