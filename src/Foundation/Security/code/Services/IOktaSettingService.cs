using Sitecore.Data.Items;
namespace MedProSC.Foundation.Security.Services
{
    public interface IOktaSettingService
    {
        Item GetOktaSettings();
    }
}