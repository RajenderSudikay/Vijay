using MedProSC.Feature.ManualForms.Models;
using MedProSC.Feature.ManualForms.Repositories;
using MedProSC.Feature.ManualForms.Services;
using RestSharp;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using static MedProSC.Feature.ManualForms.Templates;

namespace MedProSC.Feature.ManualForms.Helpers
{
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
            };

            return apiSettingsModel;
        }
    }
}