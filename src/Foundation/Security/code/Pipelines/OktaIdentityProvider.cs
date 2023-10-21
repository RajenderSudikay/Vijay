using MedProSC.Foundation.Security.Helpers;
using MedProSC.Foundation.Security.Services;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security.Notifications;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using Sitecore.Abstractions;
using Sitecore.Diagnostics;
using Sitecore.Owin.Authentication.Configuration;
using Sitecore.Owin.Authentication.Extensions;
using Sitecore.Owin.Authentication.Pipelines.IdentityProviders;
using Sitecore.Owin.Authentication.Services;
using System.Threading.Tasks;

namespace MedProSC.Foundation.Security.Pipelines
{
    using static MedProSC.Foundation.Security.Constants;

    public class OktaIdentityProvider : IdentityProvidersProcessor
    {
        protected override string IdentityProviderName => OktaDefaults.IdentityProvider;

        // OAuth provider setting
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Authority { get; set; }
        public string OAuthRedirectUri { get; set; }

        private readonly string OpenIdScope = OpenIdConnectScope.OpenIdProfile + OktaDefaults.OpenIdEmail;
        private readonly string idToken = OktaDefaults.IdToken;
        private readonly string accessDeniedRelativePath = OktaDefaults.AccessDeniedRelativePath;

        private readonly IOktaSettingService _oktaSettingService;

        protected IdentityProvider IdentityProvider { get; set; }

        public OktaIdentityProvider(FederatedAuthenticationConfiguration federatedAuthenticationConfiguration, ICookieManager cookieManager, BaseSettings settings, IOktaSettingService oktaSettingService)
            : base(federatedAuthenticationConfiguration, cookieManager, settings)
        {
            _oktaSettingService = oktaSettingService;
        }

        protected override void ProcessCore(IdentityProvidersArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            IdentityProvider = this.GetIdentityProvider();

            var oktaSettingsModel = OktaHelpers.GetOktaSettingsModel();

            if (oktaSettingsModel == null)
                return;

            var options = new OpenIdConnectAuthenticationOptions
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Authority = Authority,
                RedirectUri = OAuthRedirectUri,
                ResponseType = OpenIdConnectResponseType.CodeIdToken,
                Scope = OpenIdScope,
                AuthenticationType = IdentityProvider.Name,
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Authority,
                    NameClaimType = "email"
                },

                Notifications = new OpenIdConnectAuthenticationNotifications
                {
                    AuthenticationFailed = (AuthenticationFailedNotification<OpenIdConnectMessage, OpenIdConnectAuthenticationOptions> notification) =>
                    {
                        if (notification.Exception != null)
                        {
                            Log.Info($"Okta authorization fail with exception.\n {notification.Exception.Message}", this);

                            notification.HandleResponse();

                            // This exception should no longer be valid if we use inject KentorOwinCookieSaver middleware before OpenIdConnectAuthentication. However, we keep this code to safeguard against future.
                            if (notification.Exception.Message.Contains("IDX21323"))
                            {
                                notification.HandleResponse();
                                /* This line of code is the key to solve error 
                               IDX21323: RequireNonce is '[PII is hidden]'. OpenIdConnectProtocolValidationContext.Nonce was null, OpenIdConnectProtocol.ValidatedIdToken.Payload.Nonce was not null. 
                               The nonce cannot be validated. If you don't need to check the nonce, set OpenIdConnectProtocolValidator.RequireNonce to 'false'. Note if a 'nonce' is found it will be evaluated.
                               */
                                notification.OwinContext.Authentication.Challenge();
                                return Task.CompletedTask;
                            }
                        }

                        notification.HandleResponse();
                        notification.Response.Redirect(accessDeniedRelativePath);

                        return Task.CompletedTask;
                    },

                    AuthorizationCodeReceived = ProcessAuthorizationCodeReceived,
                    RedirectToIdentityProvider = notification =>
                    {
                        if (notification.ProtocolMessage.RequestType == OpenIdConnectRequestType.Logout)
                        {
                            // If signing out, add the id_token_hint
                            var idTokenClaim = notification.OwinContext.Authentication.User.FindFirst(idToken);

                            if (idTokenClaim != null)
                                notification.ProtocolMessage.IdTokenHint = idTokenClaim.Value;
                        }

                        return Task.CompletedTask;
                    }
                }
            };

            args.App.UseOpenIdConnectAuthentication(options);
        }

        private Task ProcessAuthorizationCodeReceived(AuthorizationCodeReceivedNotification notification)
        {
            notification.AuthenticationTicket.Identity.ApplyClaimsTransformations(new TransformationContext(this.FederatedAuthenticationConfiguration, IdentityProvider));
            return Task.CompletedTask;
        }

    }
}
