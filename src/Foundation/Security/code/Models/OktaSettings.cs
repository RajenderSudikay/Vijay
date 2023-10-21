namespace MedProSC.Foundation.Security.Models
{
    public class OktaSettings
    {
        public string ClientId { get; set; }
        public string Authority { get; set; }
        public string RedirectUri { get; set; }
        public string PostLogoutUrl { get; set; }
        public string ClientSecret { get; set; }
        public string OAuthTokenEndpoint { get; set; }
        public string OAuthUserInfoEndpoint { get; set; }
        public string OAuthLogoutEndpoint { get; set; }
        public string LoginLinkText { get; set; }
        public string LogoutLinkText { get; set; }
        public string OktaSitecoreRoles { get; set; }
    }

    public class OktaAuthModel
    {
        public bool IsUserAuthenticated { get; set; }
        public string Id_Token { get; set; }
        public string LogoutLabel { get; set; }
        public OktaSettings OktaSettings { get; set; }
    }
}