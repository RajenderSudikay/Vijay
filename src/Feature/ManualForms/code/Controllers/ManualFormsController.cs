using MedProSC.Feature.ManualForms.Models;
using MedProSC.Feature.ManualForms.Services;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;
using static MedProSC.Feature.ManualForms.Templates;

namespace MedProSC.Feature.ManualForms.Controllers
{
    public class ManualFormsController : Controller
    {
        private readonly IManualFormsService _manualFormsService;

        public ManualFormsController(IManualFormsService manualFormService)
        {
            _manualFormsService = manualFormService;
        }

        // GET: ManualForms
        public ActionResult LoadForm()
        {
            var loadFormModel = new LoadForm();
            var manualformDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(manualformDataSource))
            {
                var loadformDataSoureItem = Sitecore.Context.Database.GetItem(manualformDataSource, Sitecore.Context.Language);

                var apiSettingModel = _manualFormsService.GetManualFormsApiSettings();
                //var stateAPIRespobse = _stateService.GetStateDetailsfromAPI(apiSettingModel);

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
                        URL = !string.IsNullOrWhiteSpace(apiSettingModel.StateBaseAPI_URL) ?
                        apiSettingModel.StateBaseAPI_URL + apiSettingModel.StateAPI_URL: apiSettingModel.Base_URL + apiSettingModel.StateAPI_URL,
                        Client_id = !string.IsNullOrWhiteSpace(apiSettingModel.StateClient_id) ? apiSettingModel.StateClient_id : apiSettingModel.BaseClient_id,
                        Client_secret = !string.IsNullOrWhiteSpace(apiSettingModel.StateClient_secret) ? apiSettingModel.StateClient_secret : apiSettingModel.BaseClient_secret,
                        Type = "States"
                    });

                    loadFormModel.IssueCompanyList = _manualFormsService.GetListItemFromAPI(new APIModel()
                    {
                        URL = !string.IsNullOrWhiteSpace(apiSettingModel.ICBaseAPI_URL) ?
                         apiSettingModel.ICBaseAPI_URL + apiSettingModel.ICAPI_URL : apiSettingModel.Base_URL + apiSettingModel.ICAPI_URL,
                        Client_id = !string.IsNullOrWhiteSpace(apiSettingModel.ICClient_id) ? apiSettingModel.ICClient_id : apiSettingModel.BaseClient_id,
                        Client_secret = !string.IsNullOrWhiteSpace(apiSettingModel.ICClient_secret) ? apiSettingModel.ICClient_secret : apiSettingModel.BaseClient_secret,
                        Type = "IC"
                    });

                    loadFormModel.FormsTypeList = _manualFormsService.GetListItemFromAPI(new APIModel()
                    {
                        URL = !string.IsNullOrWhiteSpace(apiSettingModel.FTBaseAPI_URL) ?
                        apiSettingModel.FTBaseAPI_URL + apiSettingModel.FTAPI_URL : apiSettingModel.Base_URL + apiSettingModel.FTAPI_URL,
                        Client_id = !string.IsNullOrWhiteSpace(apiSettingModel.FTClient_id) ? apiSettingModel.FTClient_id : apiSettingModel.BaseClient_id,
                        Client_secret = !string.IsNullOrWhiteSpace(apiSettingModel.FTClient_secret) ? apiSettingModel.FTClient_secret : apiSettingModel.BaseClient_secret,
                        Type = "FT"
                    });
                }

            }

            return View("~/Views/ManualForms/LoadForm.cshtml", loadFormModel);
        }
    }
}