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
    public class ManualFormsController : Controller
    {
        // GET: ManualForms
        public ActionResult LoadForm()
        {
            var loadFormModel = new LoadForm();
            var manualformDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(manualformDataSource))
            {
                var headerDataSoureItem = Sitecore.Context.Database.GetItem(manualformDataSource, Sitecore.Context.Language);

                if (headerDataSoureItem != null)
                {
                    loadFormModel.LoadFormTitle = headerDataSoureItem.Fields[LoadFormTemplate.Fields.LoadFormTitle].Value;
                    loadFormModel.IssueLabel = headerDataSoureItem.Fields[LoadFormTemplate.Fields.IssueLabel].Value;
                    loadFormModel.StateLabel = headerDataSoureItem.Fields[LoadFormTemplate.Fields.StateLabel].Value;
                    loadFormModel.DateLabel = headerDataSoureItem.Fields[LoadFormTemplate.Fields.DateLabel].Value;
                    loadFormModel.FormsTypeLabel = headerDataSoureItem.Fields[LoadFormTemplate.Fields.FormsTypeLabel].Value;
                    loadFormModel.LoadFormButtonText = headerDataSoureItem.Fields[LoadFormTemplate.Fields.LoadFormButtonText].Value;


                }
            }

            return View("~/Views/ManualForms/LoadForm.cshtml", loadFormModel);
        }
    }
}