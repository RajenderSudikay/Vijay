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
    public class BuilderTableController : Controller
    {
        // GET: ManualForms
        public ActionResult BuilderTable()
        {
            var builderTableModel = new BuilderTable();
            var manualformDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(manualformDataSource))
            {
                var builderTableDataSoureItem = Sitecore.Context.Database.GetItem(manualformDataSource, Sitecore.Context.Language);

                if (builderTableDataSoureItem != null)
                {
                    builderTableModel.FormNumber = builderTableDataSoureItem.Fields[BuildTableTemplate.Fields.FormNumber].Value;
                    builderTableModel.FormName = builderTableDataSoureItem.Fields[BuildTableTemplate.Fields.FormName].Value;
                    builderTableModel.Occurences = builderTableDataSoureItem.Fields[BuildTableTemplate.Fields.Occurences].Value;
                    builderTableModel.ClaimsMade = builderTableDataSoureItem.Fields[BuildTableTemplate.Fields.ClaimsMade].Value;
                    builderTableModel.EffectiveDate = builderTableDataSoureItem.Fields[BuildTableTemplate.Fields.EffectiveDate].Value;
                    builderTableModel.ExpirationDate = builderTableDataSoureItem.Fields[BuildTableTemplate.Fields.ExpirationDate].Value;


                }
            }

            return View("~/Views/ManualForms/BuilderTable.cshtml", builderTableModel);
        }
    }
}