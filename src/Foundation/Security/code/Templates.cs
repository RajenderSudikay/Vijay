using Sitecore.Data;

namespace MedProSC.Foundation.Security
{
    public class Templates
    {
        public struct MedProOkta
        {
            public static readonly ID SettingTemplateID = new ID("{1A60D509-0354-4D6A-98E7-41BCEA32B530}");
            public static readonly ID SettingFolderTemplateID = new ID("{4B092383-C6CE-4C64-A6C5-9F69780A577A}");
            public static readonly ID SettingFolderItemID = new ID("{D7E2A214-78AB-47EB-980E-A106E30DA236}");

            public struct Fields
            {
                public static readonly ID Environment = new ID("{A91F510B-935E-4300-A643-E30C24114E94}");
                public static readonly ID Authority = new ID("{92293C99-4F8C-4C34-87D2-00D442E8BE79}");
                public static readonly ID ClientId = new ID("{AE16209C-4AF8-45C4-8B20-BB5C79766CF9}");
                public static readonly ID ClientSecret = new ID("{4A42A257-1855-412E-B65A-BDB19AC9BAA3}");
                public static readonly ID OAuthTokenEndpoint = new ID("{E1F680AD-E365-4B6A-A7E4-213B37E2AC87}");
                public static readonly ID OAuthUserInfoEndpoint = new ID("{F2CFCC8D-3FD1-4181-A6E9-39089A034ECD}");
                public static readonly ID PostLogoutRedirectURI = new ID("{9239AA61-1A78-46A6-ABA1-1391072C9E02}");
                public static readonly ID RedirectURI = new ID("{E046FA74-2591-4C13-A9C8-0BF5663C5E0E}");
                public static readonly ID OAuthLogoutEndpoint = new ID("{74E293BA-3C7D-415E-8409-B0FA020BA175}");
                public static readonly ID LoginLinkText = new ID("{90A931FE-FB47-4107-946F-F632DBEB1FF5}");
                public static readonly ID LogoutLinkText = new ID("{1FDAFC5E-0243-44C1-97A4-BBDAA1AF243D}");
                public static readonly ID OktaSitecoreRoles = new ID("{E504B6B1-61C5-4755-A509-BFC4DAF2242E}");
            }
        }
    }
}