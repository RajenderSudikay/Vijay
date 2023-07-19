using Sitecore.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Sitecore.Shell.UserOptions.HtmlEditor;
using Sitecore.Mvc;
using Sitecore.Mvc.Presentation;
using MedProSC.Project.Website.Models;

namespace MedProSC.Project.Website.Controllers
{
    public class HeaderController : Controller
    {
        // GET: Header
        public ActionResult Header()
        {
            var headerModel = new HeaderModel();
            var headerDataSource = RenderingContext.Current.Rendering.DataSource;
            if(!string.IsNullOrWhiteSpace( headerDataSource))
            {
                var headerDataSoureItem = Sitecore.Context.Database.GetItem(headerDataSource, Sitecore.Context.Language);
            
                if(headerDataSoureItem != null)
                {
                    headerModel.HeaderTitle = headerDataSoureItem.Fields["HeaderTitle"].Value;
                    headerModel.FormBuilderTitle = headerDataSoureItem.Fields["FormBuilderTitle"].Value;
                    headerModel.BundleHistoryTitle = headerDataSoureItem.Fields["BundleHistoryTitle"].Value;
                }
            }
            return View("~/Views/Shared/Header.cshtml", headerModel);
        }
    }
}