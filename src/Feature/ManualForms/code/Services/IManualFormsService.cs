using MedProSC.Feature.ManualForms.Models;
using RestSharp;
using Sitecore.Data.Items;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MedProSC.Feature.ManualForms.Services
{
    public interface IManualFormsService
    {
        Item GetApiSettings();
        //IRestResponse GetStateDetailsfromAPI(ManualFormsAPISettings apiSettingModel);
        ManualFormsAPISettings GetManualFormsApiSettings();

        IList<SelectListItem> GetListItemFromAPI(APIModel apiModel);
    }
   
}