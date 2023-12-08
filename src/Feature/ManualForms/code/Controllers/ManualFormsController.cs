using MedProSC.Feature.ManualForms.Models;
using MedProSC.Feature.ManualForms.Services;
using Sitecore.Diagnostics;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using static MedProSC.Feature.ManualForms.Templates;

namespace MedProSC.Feature.ManualForms.Controllers
{
    public class ManualFormsController : Controller, IController
    {
        private readonly IManualFormsService _manualFormsService;
        private readonly ManualFormsAPISettings apiSettingModel;

        public ManualFormsController(IManualFormsService manualFormService)
        {
            _manualFormsService = manualFormService;
            apiSettingModel = _manualFormsService.GetManualFormsApiSettings();
        }

        // GET: ManualForms
        public ActionResult LoadForm()
        {
            var loadFormModel = new LoadForm();
            var manualformDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(manualformDataSource))
            {
                var loadformDataSoureItem = Sitecore.Context.Database.GetItem(manualformDataSource, Sitecore.Context.Language);
                //var apiSettingModel = _manualFormsService.GetManualFormsApiSettings();

                if (loadformDataSoureItem != null)
                {
                    loadFormModel.LoadFormTitle = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.LoadFormTitle].Value;
                    loadFormModel.IssueLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.IssueLabel].Value;
                    loadFormModel.StateLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.StateLabel].Value;
                    loadFormModel.DateLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.DateLabel].Value;
                    loadFormModel.FormsTypeLabel = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.FormsTypeLabel].Value;
                    loadFormModel.LoadFormButtonText = loadformDataSoureItem.Fields[LoadFormTemplate.Fields.LoadFormButtonText].Value;

                    loadFormModel.StateList = _manualFormsService.GetListItemFromAPI(new APIModel()
                    {
                        URL = apiSettingModel.Base_URL + apiSettingModel.StateAPI_URL,
                        Client_id = apiSettingModel.BaseClient_id,
                        Client_secret = apiSettingModel.BaseClient_secret,
                        Type = "States"
                    });

                    loadFormModel.IssueCompanyList = _manualFormsService.GetListItemFromAPI(new APIModel()
                    {
                        URL = apiSettingModel.Base_URL + apiSettingModel.ICAPI_URL,
                        Client_id = apiSettingModel.BaseClient_id,
                        Client_secret = apiSettingModel.BaseClient_secret,
                        Type = "IC"
                    });

                    loadFormModel.FormsTypeList = _manualFormsService.GetListItemFromAPI(new APIModel()
                    {
                        URL = apiSettingModel.Base_URL + apiSettingModel.FTAPI_URL,
                        Client_id = apiSettingModel.BaseClient_id,
                        Client_secret = apiSettingModel.BaseClient_secret,
                        Type = "FT"
                    });

                    loadFormModel.LoadForms = _manualFormsService.GetLoadForms(new APIModel()
                    {
                        URL = apiSettingModel.Base_URL + apiSettingModel.FTAPI_URL,
                        Client_id = apiSettingModel.BaseClient_id,
                        Client_secret = apiSettingModel.BaseClient_secret,
                        Type = "LF"
                    });
                }
            }

            return View("~/Views/ManualForms/LoadForm.cshtml", loadFormModel);
        }


        public JsonResult GetLoadForms(LoadFormSearchModel SearchModel)
        {
            var loadFormsResponse = _manualFormsService.GetLoadForms(new APIModel()
            {
                URL = apiSettingModel.Base_URL + apiSettingModel.LFAPI_URL,
                Client_id = apiSettingModel.BaseClient_id,
                Client_secret = apiSettingModel.BaseClient_secret,
                Type = "LF"
            }); ;

            return Json(loadFormsResponse, JsonRequestBehavior.AllowGet);
        }
    }
}