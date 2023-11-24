namespace MedProSC.Feature.ManualForms.Models
{
    public class ManualFormsAPISettings
    {
        public string Environment { get; set; }      
        public string Base_URL { get; set; }
        public string BaseClient_id { get; set; }
        public string BaseClient_secret { get; set; }
        public string Timeout { get; set; }
        public string CacheDuration { get; set; }

        public string StateBaseAPI_URL { get; set; }
        public string StateAPI_URL { get; set; }
        public string StateClient_id { get; set; }
        public string StateClient_secret { get; set; }

        public string ICBaseAPI_URL { get; set; }
        public string ICAPI_URL { get; set; }
        public string ICClient_id { get; set; }
        public string ICClient_secret { get; set; }

        public string FTBaseAPI_URL { get; set; }
        public string FTAPI_URL { get; set; }
        public string FTClient_id { get; set; }
        public string FTClient_secret { get; set; }


        public string LFBaseAPI_URL { get; set; }
        public string LFAPI_URL { get; set; }
        public string LFClient_id { get; set; }
        public string LFClient_secret { get; set; }

    }

    public class APIModel
    {
        public string Client_id { get; set; }
        public string URL { get; set; }
        public string Client_secret { get; set; }
        public string Type { get; set; }
    }
}