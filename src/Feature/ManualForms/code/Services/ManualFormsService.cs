using Sitecore.Data.Items;
using MedProSC.Feature.ManualForms.Repositories;
using RestSharp;
using RestSharp.Authenticators;
using Sitecore.Diagnostics;
using System;
using MedProSC.Feature.ManualForms.Models;
using Sitecore.Pipelines.RenderItemTile;
using Sitecore.Web.UI.WebControls;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.IO;
using Microsoft.Ajax.Utilities;
using System.Linq;
using System.Web.Helpers;

namespace MedProSC.Feature.ManualForms.Services
{
    using static Helpers.ApiHelpers;

    public class ManualFormsService : IManualFormsService
    {
        private readonly IManualFormsRepository _apiRepository;
        private readonly IRestClient _restClient;


        public ManualFormsService(IManualFormsRepository apiRepository, IRestClient restClient)
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

        //public IRestResponse GetStateDetailsfromAPI(ManualFormsAPISettings apiSettingModel)
        //{
        //    var request = new RestRequest(apiSettingModel.Base_URL, RestSharp.Method.GET);
        //    request.AddHeader("client_id", apiSettingModel.Client_id);
        //    request.AddHeader("client_secret", apiSettingModel.Client_secret);
        //    request.AddHeader("X-Correlation-Id", "123456789");
        //    request.AddHeader("Accept", "application/json");
        //    var response = _restClient.Execute(request);

        //    Console.WriteLine(response.Content);
        //    return response;
        //}

        public IList<SelectListItem> GetListItemFromAPI(APIModel apiModel)
        {
            var dropdownListItems = new List<SelectListItem>();

            //For local only
            dynamic response = null;
            if (response == null)
            {
                if (apiModel.Type == "States")
                {
                    using (StreamReader r = new StreamReader(@"C:\\vijay\\APIS\\States_Resp.json"))
                    {
                        var json = r.ReadToEnd();
                        var apiResponse = JsonConvert.DeserializeObject<APIResponseModel.StateRoot>(json);
                        dropdownListItems.AddRange(apiResponse.states.Select(item => new SelectListItem
                        {
                            Text = item.stateCode,
                            Value = item.state.ToString()
                        }));
                    }
                }

                if (apiModel.Type == "IC")
                {
                    using (StreamReader r = new StreamReader(@"C:\\vijay\\APIS\\Issue_Company_API_JSON.json"))
                    {
                        var json = r.ReadToEnd();
                        var apiResponse = JsonConvert.DeserializeObject<APIResponseModel.IssueCompaniesRoot>(json);
                        dropdownListItems.AddRange(apiResponse.issueCompanies.Select(item => new SelectListItem
                        {
                            Text = item.Description,
                            Value = item.Code
                        }));
                    }
                }

                if (apiModel.Type == "FT")
                {
                    //using (StreamReader r = new StreamReader(@"C:\\vijay\\APIS\\LoadForms_API_JSON.json"))
                    //{
                    //    var json = r.ReadToEnd();
                    //    var apiResponse = JsonConvert.DeserializeObject<APIResponseModel.IssueCompaniesRoot>(json);
                    //    dropdownListItems.AddRange(apiResponse.issueCompanies.Select(item => new SelectListItem
                    //    {
                    //        Text = item.Description,
                    //        Value = item.Code
                    //    }));

                    //}
                }

            }
            else
            {
                if( !string.IsNullOrWhiteSpace(apiModel.URL) && !string.IsNullOrWhiteSpace(apiModel.Client_id) && !string.IsNullOrWhiteSpace(apiModel.Client_secret))
                {
                    var request = new RestRequest(apiModel.URL, RestSharp.Method.GET);
                    request.AddHeader("client_id", apiModel.Client_id);
                    request.AddHeader("client_secret", apiModel.Client_secret);
                    request.AddHeader("X-Correlation-Id", "123456789");
                    request.AddHeader("Accept", "application/json");
                    response = _restClient.Execute(request);
                    if (apiModel.Type == "States" && response != null)
                    {

                        APIResponseModel.StateRoot apiResponse = JsonConvert.DeserializeObject<APIResponseModel.StateRoot>(response.Content);

                        if (apiResponse != null && apiResponse.states != null)
                        {
                            dropdownListItems.AddRange(apiResponse.states.Select(item => new SelectListItem
                            {
                                Text = item.stateCode,
                                Value = item.state
                            }));
                        }
                    }

                    if ((apiModel.Type == "IC" || apiModel.Type == "FT") && response != null)
                    {
                        APIResponseModel.IssueCompaniesRoot apiResponse = JsonConvert.DeserializeObject<APIResponseModel.IssueCompaniesRoot>(response.Content);
                        if (apiResponse != null && apiResponse.issueCompanies != null)
                        {
                            dropdownListItems.AddRange(apiResponse.issueCompanies.Select(item => new SelectListItem
                            {
                                Text = item.Description,
                                Value = item.Code
                            }));
                        }
                    }
                }
            }
               

            return dropdownListItems;
        }
    }
}