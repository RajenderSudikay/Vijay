using Sitecore.Data.Items;
using MedProSC.Feature.ManualForms.Repositories;
using RestSharp;
using RestSharp.Authenticators;
using Sitecore.Diagnostics;
using System;
using MedProSC.Feature.ManualForms.Models;
using Sitecore.Pipelines.RenderItemTile;

namespace MedProSC.Feature.ManualForms.Services
{
    using static Helpers.ApiHelpers;
    public class StateService : IStateService
    {
        private readonly IStateRepository _apiRepository;
        private readonly IRestClient _restClient;


        public StateService(IStateRepository apiRepository, IRestClient restClient)
        {
            _apiRepository = apiRepository;
            _restClient = restClient;
        }
        public Item GetApiSettings()
        {
            return _apiRepository.GetApiSettingItemBasedOnEnvironment();
        }

        public ManualFormsAPISettings GetManualFormsApiSettings()
        {
            var apiSettingItem = GetApiSettings();
          return GetManualFormsSettingModel(apiSettingItem);

        }

        public IRestResponse GetStateDetailsfromAPI(ManualFormsAPISettings apiSettingModel)
        {
            var apiURL = apiSettingModel.Base_URL + "?countryCode=USA";
            var request = new RestRequest("https://mule-mpg.nft2.medpro.com/api/mpg-enterprise-data-xp/v1/policies/AS0000/states?countryCode=USA", Method.GET);
            request.AddHeader("client_id", "0oa1sqy7cvbtI8Esl0h8");
            request.AddHeader("client_secret", "2Vqmxc4bhVs8TvGtPlCoG_TgFagOMpf-LDOqIQN_0XhoOved2uDt-ZxPsLOw86At ");
            request.AddHeader("X-Correlation-Id", "123456789");
            request.AddHeader("Accept", "application/json");
            var response = _restClient.Execute(request);

            Console.WriteLine(response.Content);
            return response;
        }
    }
}