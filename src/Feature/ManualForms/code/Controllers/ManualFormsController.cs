using MedProSC.Feature.ManualForms.Models;
using MedProSC.Feature.ManualForms.Services;
using Sitecore.IO;
using Sitecore.Mvc.Controllers;
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
        private readonly IStateService _stateService;

        public ManualFormsController(IStateService stateService)
        {
            _stateService = stateService;
        }

        // GET: ManualForms
        public ActionResult LoadForm()
        {
            var loadFormModel = new LoadForm();
            var manualformDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(manualformDataSource))
            {
                var loadformDataSoureItem = Sitecore.Context.Database.GetItem(manualformDataSource, Sitecore.Context.Language);
                var apiSettingItem = _stateService.GetApiSettings();

                if (loadformDataSoureItem != null)
                {
                    loadFormModel.LoadFormTitle = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.LoadFormTitle].Value;
                    loadFormModel.IssueLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.IssueLabel].Value;
                    loadFormModel.StateLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.StateLabel].Value;
                    loadFormModel.DateLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.DateLabel].Value;
                    loadFormModel.FormsTypeLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.FormsTypeLabel].Value;
                    loadFormModel.LoadFormButtonText = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.LoadFormButtonText].Value;

                }
               
            }

            return View("~/Views/ManualForms/LoadForm.cshtml", loadFormModel);
        }
    }
}