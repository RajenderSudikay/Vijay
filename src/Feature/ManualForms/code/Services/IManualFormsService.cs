using MedProSC.Feature.ManualForms.Models;
using RestSharp;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Web.Mvc;
using static MedProSC.Feature.ManualForms.Models.APIResponseModel;
using static MedProSC.Feature.ManualForms.Models.CreateBundleModel;

namespace MedProSC.Feature.ManualForms.Services
{
    public interface IManualFormsService
    {
        Item GetApiSettings();
        //IRestResponse GetStateDetailsfromAPI(ManualFormsAPISettings apiSettingModel);
        ManualFormsAPISettings GetManualFormsApiSettings();

        IList<SelectListItem> GetListItemFromAPI(APIModel apiModel);

        LoadFormsRoot GetLoadForms(APIModel apiModel);

        CreateBundleResponseRoot CreateBundle(APIModel apiModel);
    }
   
}