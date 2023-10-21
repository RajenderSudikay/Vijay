using MedProSC.Foundation.Security.Helpers;
using Sitecore.Data.Items;
using System.Linq;

namespace MedProSC.Foundation.Security.Repositories
{
    using static Constants;
    using static Templates;

    public class OktaSettingRepository : IOktaSettingRepository
    {
        public Item GetOktaSettingItemBasedOnEnvironment()
        {
            var environment = OktaHelpers.GetEnvironment();

            if (!string.IsNullOrWhiteSpace(environment))
            {
                var oktaSettingFolderItem = Sitecore.Data.Database.GetDatabase(OktaDefaults.Database).GetItem(Templates.MedProOkta.SettingFolderItemID);

                if (oktaSettingFolderItem == null)
                    return null;

                var RequiredSettingItemByEnvironment = oktaSettingFolderItem.Children.Where(val => val.Fields[MedProOkta.Fields.Environment].ToString().ToLowerInvariant() == environment.ToLowerInvariant()).FirstOrDefault();

                if (RequiredSettingItemByEnvironment == null)
                    return null;

                return RequiredSettingItemByEnvironment;
            }
            return null;
        }
    }
}