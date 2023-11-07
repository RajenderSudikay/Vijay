using MedProSC.Feature.ManualForms.Helpers;
using Sitecore.Data.Items;
using System.Linq;
using static MedProSC.Feature.ManualForms.Templates;

namespace MedProSC.Feature.ManualForms.Repositories
{
    using static Templates;
    public class StateRepository : IStateRepository
    {
        public Item GetApiSettingItemBasedOnEnvironment()
        {
            var environment = ApiHelpers.GetEnvironment();

            if (!string.IsNullOrWhiteSpace(environment))
            {
                var apiSettingFolderItem = Sitecore.Context.Database.GetItem(ManualFormsAPISetting.SettingItemFolderID);

                if (apiSettingFolderItem == null)
                    return null;

                var RequiredSettingItemByEnvironment = apiSettingFolderItem.Children.Where(val => val.Fields[ManualFormsAPISetting.Fields.Environment].ToString().ToLowerInvariant() == environment.ToLowerInvariant()).FirstOrDefault();

                if (RequiredSettingItemByEnvironment == null)
                    return null;

                return RequiredSettingItemByEnvironment;
            }
            return null;
        }
    }
}