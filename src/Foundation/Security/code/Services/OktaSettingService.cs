using Sitecore.Data.Items;
using MedProSC.Foundation.Security.Repositories;

namespace MedProSC.Foundation.Security.Services
{
    public class OktaSettingService : IOktaSettingService
    {
        private readonly IOktaSettingRepository _oktaSettingRepository;

        public OktaSettingService(IOktaSettingRepository oktaSettingRepository)
        {
            _oktaSettingRepository = oktaSettingRepository;
        }

        public Item GetOktaSettings()
        {
            return _oktaSettingRepository.GetOktaSettingItemBasedOnEnvironment();
        }

    }
}