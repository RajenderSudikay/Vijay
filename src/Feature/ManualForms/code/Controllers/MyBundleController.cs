using MedProSC.Feature.ManualForms.Models;
using Sitecore.IO;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MedProSC.Feature.ManualForms.Templates;
using static Sitecore.Shell.UserOptions.HtmlEditor;

namespace MedProSC.Feature.ManualForms.Controllers
{
    public class MyBundleController : Controller
    {
        // GET: ManualForms
        public ActionResult MyBundle()
        {
            var myBundleModel = new MyBundle();
            var manualformDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(manualformDataSource))
            {
                var myBundleDataSoureItem = Sitecore.Context.Database.GetItem(manualformDataSource, Sitecore.Context.Language);

                if (myBundleDataSoureItem != null)
                {
                    myBundleModel.MyBundleTitle = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.MyBundleTitle].Value;
                    myBundleModel.FormNumber = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.FormNumber].Value;
                    myBundleModel.FormName = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.FormName].Value;
                    myBundleModel.PolocyNumber = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.PolocyNumber].Value;
                    myBundleModel.TransactionType = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.TransactionType].Value;
                    myBundleModel.CreateBundle = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.CreateBundle].Value;
                    myBundleModel.Description = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.Description].Value;
                    myBundleModel.FirstNamedInsured = myBundleDataSoureItem.Fields[MyBundleTemplate.Fields.FirstNamedInsured].Value;

                }
            }

            return View("~/Views/ManualForms/MyBundle.cshtml", myBundleModel);
        }
    }
}