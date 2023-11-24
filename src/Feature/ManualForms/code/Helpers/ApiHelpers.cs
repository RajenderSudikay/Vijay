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
        static IRestClient restClient= new RestClient();
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

                StateBaseAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.StateAlternateBaseURL].Value,
                StateAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.StateAPI_URL].Value,
                StateClient_id = apiSettingItem.Fields[ManualFormsAPISetting.Fields.StateAlternateClient_id].Value,
                StateClient_secret = apiSettingItem.Fields[ManualFormsAPISetting.Fields.StateAlternateClient_secret].Value,

                FTBaseAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.FTAlternateBaseURL].Value,
                FTAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.FTAPI_URL].Value,
                FTClient_id = apiSettingItem.Fields[ManualFormsAPISetting.Fields.AlternateFTClient_id].Value,
                FTClient_secret = apiSettingItem.Fields[ManualFormsAPISetting.Fields.AlternateFTClient_secret].Value,

                ICBaseAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.ICAlternateBaseURL].Value,
                ICAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.ICAPI_URL].Value,
                ICClient_id = apiSettingItem.Fields[ManualFormsAPISetting.Fields.ICAlternateClient_id].Value,
                ICClient_secret = apiSettingItem.Fields[ManualFormsAPISetting.Fields.ICAlternateClient_secret].Value,

                LFBaseAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.LFAlternateBaseURL].Value,
                LFAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.LFAPI_URL].Value,
                LFClient_id = apiSettingItem.Fields[ManualFormsAPISetting.Fields.AlternateLFClient_id].Value,
                LFClient_secret = apiSettingItem.Fields[ManualFormsAPISetting.Fields.AlternateLFClient_secret].Value,

            };

            return apiSettingsModel;
        }
    }
}