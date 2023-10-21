using Sitecore.Data.Items;

namespace MedProSC.Foundation.Security.Repositories
{
    public interface IOktaSettingRepository
    {
        Item GetOktaSettingItemBasedOnEnvironment();
    }
}