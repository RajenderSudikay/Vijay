using MedProSC.Foundation.Security.Repositories;
using MedProSC.Foundation.Security.Services;
using Sitecore.Diagnostics;
using MedProSC.Foundation.Security.Models;
using static MedProSC.Foundation.Security.Templates;

namespace MedProSC.Foundation.Security.Helpers
{
    public class OktaHelpers
    {
        static IOktaSettingRepository OktaSetttingsRepository = new OktaSettingRepository();
        static IOktaSettingService OktaSetttingsService = new OktaSettingService(OktaSetttingsRepository);

        public static string GetEnvironment()
        {
            return System.Configuration.ConfigurationManager.AppSettings["env:define"];
        }

        public static OktaSettings GetOktaSettingsModel()
        {
            var oktaSettingItem = OktaSetttingsService.GetOktaSettings();

            if (oktaSettingItem == null)
            {
                Log.Warn("OKTA Setting Item missing. Please configure setting", "OKTA Heper Error");
                return null;
            }

            OktaSettings oktaSettingsModel = new OktaSettings()
            {
                Authority = oktaSettingItem.Fields[MedProOkta.Fields.Authority].Value,
                ClientId = oktaSettingItem.Fields[MedProOkta.Fields.ClientId].Value,
                ClientSecret = oktaSettingItem.Fields[MedProOkta.Fields.ClientSecret].Value,
                OAuthTokenEndpoint = oktaSettingItem.Fields[MedProOkta.Fields.OAuthTokenEndpoint].Value,
                OAuthUserInfoEndpoint = oktaSettingItem.Fields[MedProOkta.Fields.OAuthUserInfoEndpoint].Value,
                PostLogoutUrl = oktaSettingItem.Fields[MedProOkta.Fields.PostLogoutRedirectURI].Value,
                RedirectUri = oktaSettingItem.Fields[MedProOkta.Fields.RedirectURI].Value,
                OAuthLogoutEndpoint = oktaSettingItem.Fields[MedProOkta.Fields.OAuthLogoutEndpoint].Value,
                LoginLinkText = oktaSettingItem.Fields[MedProOkta.Fields.LoginLinkText].Value,
                LogoutLinkText = oktaSettingItem.Fields[MedProOkta.Fields.LogoutLinkText].Value,
                OktaSitecoreRoles = oktaSettingItem.Fields[MedProOkta.Fields.OktaSitecoreRoles].Value
            };

            return oktaSettingsModel;
        }
    }
}