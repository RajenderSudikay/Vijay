using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Sitecore.Owin.Authentication.Identity;
using Sitecore.Owin.Authentication.Services;
using Sitecore.SecurityModel.Cryptography;

namespace MedProSC.Foundation.Security
{
    public class ExternalUserBuilder : DefaultExternalUserBuilder
    {
        public ExternalUserBuilder(ApplicationUserFactory applicationUserFactory, IHashEncryption hashEncryption) : base(applicationUserFactory, hashEncryption)
        {

        }

        protected override string CreateUniqueUserName(UserManager<ApplicationUser> userManager, ExternalLoginInfo externalLoginInfo)
        {

            string domain =
                (this.FederatedAuthenticationConfiguration.GetIdentityProvider(externalLoginInfo.ExternalIdentity) ??
                 throw new InvalidOperationException("Unable to retrieve an identity provider for the given identity"))
                .Domain;
            return $"{domain}\\{externalLoginInfo.Email}";
        }

        public override ApplicationUser BuildUser(UserManager<ApplicationUser> userManager, ExternalLoginInfo externalLoginInfo)
        {
            var username = this.CreateUniqueUserName(userManager, externalLoginInfo);
            var user = this.ApplicationUserFactory.CreateUser(username);
            user.IsVirtual = !this.IsPersistentUser;
            user.Email = externalLoginInfo.Email;
            userManager.Update(user);
            return user;
        }
    }
}