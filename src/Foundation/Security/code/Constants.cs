namespace MedProSC.Foundation.Security
{
    public static class Constants
    {
        public struct OktaDefaults
        {
            public static readonly string IdToken = "id_token";
            public static readonly string IdentityProvider = "Okta";
            public static readonly string OpenIdEmail = " email";
            public static readonly string AccessDeniedRelativePath = "/access-denied";
            public static readonly string ClaimType = "name";
            public static readonly string RequireNonceDeaultValue = "IDX21323";
            public const string Database = "web";            
        }
    }
}