using MedProSC.Feature.ManualForms.Models;
using RestSharp;
using Sitecore.Data.Items;

namespace MedProSC.Feature.ManualForms.Services
{
    public interface IStateService
    {
        Item GetApiSettings();
        IRestResponse GetStateDetailsfromAPI(ManualFormsAPISettings apiSettingModel);
        ManualFormsAPISettings GetManualFormsApiSettings();
    }
   
}