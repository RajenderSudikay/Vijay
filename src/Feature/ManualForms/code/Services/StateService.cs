using Sitecore.Data.Items;
using MedProSC.Feature.ManualForms.Repositories;

namespace MedProSC.Feature.ManualForms.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _apiRepository;

        public StateService(IStateRepository apiRepository)
        {
            _apiRepository = apiRepository;
        }
        public Item GetApiSettings()
        {
            return _apiRepository.GetApiSettingItemBasedOnEnvironment();
        }
    }
}