using MedProSC.Feature.ManualForms.Models;
using MedProSC.Feature.ManualForms.Repositories;
using Newtonsoft.Json;
using RestSharp;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace MedProSC.Feature.ManualForms.Services
{
    using static Constants.APIHeaders;
    using static Helpers.ApiHelpers;
    using static MedProSC.Feature.ManualForms.Models.APIResponseModel;

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

            }
            else
            {
                if (!string.IsNullOrWhiteSpace(apiModel.URL) && !string.IsNullOrWhiteSpace(apiModel.Client_id) && !string.IsNullOrWhiteSpace(apiModel.Client_secret))
                {
                    response = GetAPIResponse(apiModel);
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

        private dynamic GetAPIResponse(APIModel apiModel)
        {
            dynamic response;
            var request = new RestRequest(apiModel.URL, RestSharp.Method.GET);
            request.AddHeader(Client_id, apiModel.Client_id);
            request.AddHeader(Client_secret, apiModel.Client_secret);
            request.AddHeader(XCorrelationId, "123456789");
            request.AddHeader(Accept, RequestAcceptType);
            response = _restClient.Execute(request);
            return response;
        }

        public LoadFormsRoot GetLoadForms(APIModel apiModel)
        {
            dynamic localresponse = null;
            if (localresponse == null)
            {
                if (apiModel.Type == "LF")
                {
                    using (StreamReader r = new StreamReader(@"C:\\vijay\\APIS\\LoadForms_API_JSON.json"))
                    {
                        var json = r.ReadToEnd();
                        var apiResponse = JsonConvert.DeserializeObject<APIResponseModel.LoadFormsRoot>(json);
                       
                        return apiResponse;
                    }
                }
            }

            else if (!string.IsNullOrWhiteSpace(apiModel.URL) && !string.IsNullOrWhiteSpace(apiModel.Client_id) && !string.IsNullOrWhiteSpace(apiModel.Client_secret))
            {
                var response = GetAPIResponse(apiModel);

                if (apiModel.Type == "LF" && response != null)
                {
                    APIResponseModel.LoadFormsRoot loadFormsResponse = JsonConvert.DeserializeObject<APIResponseModel.LoadFormsRoot>(response.Content);
                    if (loadFormsResponse != null && loadFormsResponse.forms != null)
                    {
                        return loadFormsResponse;
                    }
                }
            }

            return new LoadFormsRoot();

        }
    }
}