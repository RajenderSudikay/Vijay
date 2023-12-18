using MedProSC.Feature.ManualForms.Models;
using MedProSC.Feature.ManualForms.Repositories;
using MedProSC.Feature.ManualForms.Services;
using Newtonsoft.Json;
using RestSharp;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using static MedProSC.Feature.ManualForms.Models.CreateBundleModel;
using System.Collections.Generic;
using System.Linq;
using static MedProSC.Feature.ManualForms.Templates;

namespace MedProSC.Feature.ManualForms.Helpers
{
    using static Constants.Common;

    public class ApiHelpers
    {
        static IManualFormsRepository StateRepository = new ManualFormsRepository();
        static IRestClient restClient = new RestClient();
        static IManualFormsService StateService = new ManualFormsService(StateRepository, restClient);

        public static string GetEnvironment()
        {
            return System.Configuration.ConfigurationManager.AppSettings["env:define"];
        }

        public static ManualFormsAPISettings GetManualFormsSettingModel(Item apiSettingItem)
        {

            if (apiSettingItem == null)
            {
                Log.Warn("Api Setting Item missing. Please configure setting", "Api Heper Error");
                return null;
            }

            ManualFormsAPISettings apiSettingsModel = new ManualFormsAPISettings()
            {
                Environment = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Environment].Value,
                Base_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Base_URL].Value,
                BaseClient_id = apiSettingItem.Fields[ManualFormsAPISetting.Fields.ClientID].Value,
                BaseClient_secret = apiSettingItem.Fields[ManualFormsAPISetting.Fields.ClientSecret].Value,
                Timeout = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Timeout].Value,
                CacheDuration = apiSettingItem.Fields[ManualFormsAPISetting.Fields.CacheDuration].Value,

                StateAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.StateAPI_URL].Value,
                FTAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.FTAPI_URL].Value,
                ICAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.ICAPI_URL].Value,
                LFAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.LFAPI_URL].Value,
                CBAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.CBAPI_URL].Value,
            };

            return apiSettingsModel;
        }

        public static CreateBundlePostRequest PostCreateBundleRequest(CreateBundle BundleModel)
        {
            return new CreateBundlePostRequest()
            {
                firstNamedInsured = BundleModel.firstNamedInsured,
                createdBy = ((System.Security.Claims.ClaimsIdentity)Sitecore.Context.User.Identity).Claims.Where(x => x.Type == claim_preferredusername).FirstOrDefault().Value.ToString().Split('@')[0],
                description = BundleModel.description,
                forms = JsonConvert.DeserializeObject<List<Form>>(BundleModel.forms),
                formType = BundleModel.formType,
                insuredScheduleData = BundleModel.insuredScheduleData,
                modifiedOnDate = System.DateTime.Now,
                policyEffectiveDate = BundleModel.policyEffectiveDate,
                policyNumber = BundleModel.policyNumber,
                state = BundleModel.state,
                transactionType = BundleModel.transactionType,

            };
        }
    }
}