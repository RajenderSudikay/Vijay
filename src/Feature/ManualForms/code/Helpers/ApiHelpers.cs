using MedProSC.Feature.ManualForms.Models;
using MedProSC.Feature.ManualForms.Repositories;
using MedProSC.Feature.ManualForms.Services;
using Sitecore.Diagnostics;
using static MedProSC.Feature.ManualForms.Templates;

namespace MedProSC.Feature.ManualForms.Helpers
{
    public class ApiHelpers
    {
        static IStateRepository StateRepository = new StateRepository();
        static IStateService StateService = new StateService(StateRepository);

        public static string GetEnvironment()
        {
            return System.Configuration.ConfigurationManager.AppSettings["env:define"];
        }

        public static ManualFormsAPISettings GetOktaSettingsModel()
        {
            var apiSettingItem = StateService.GetApiSettings();

            if (apiSettingItem == null)
            {
                Log.Warn("Api Setting Item missing. Please configure setting", "Api Heper Error");
                return null;
            }

            ManualFormsAPISettings apiSettingsModel = new ManualFormsAPISettings()
            {
                Environment = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Environment].Value,
                Client_id = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Client_id].Value,
                Base_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Base_URL].Value,
                Client_secret = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Client_secret].Value,
                Timeout = apiSettingItem.Fields[ManualFormsAPISetting.Fields.Timeout].Value,
                CacheDuration = apiSettingItem.Fields[ManualFormsAPISetting.Fields.CacheDuration].Value,
                FormsTypeAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.FormsTypeAPI_URL].Value,
                IssueCompanyAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.IssueCompanyAPI_URL].Value,
                LoadFormsAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.LoadFormsAPI_URL].Value,
                StateAPI_URL = apiSettingItem.Fields[ManualFormsAPISetting.Fields.StateAPI_URL].Value
            };

            return apiSettingsModel;
        }
    }
}