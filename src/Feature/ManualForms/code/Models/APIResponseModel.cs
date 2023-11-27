using Newtonsoft.Json;
using System.Collections.Generic;

namespace MedProSC.Feature.ManualForms.Models
{
    public class APIResponseModel
    {
        public class StateRoot
        {
            public List<StateInfo> states { get; set; }
        }

        public class IssueCompaniesRoot
        {
            public List<CodeDescription> issueCompanies { get; set; }
        }

        public class LoadFormsRoot
        {
            public List<Form> forms { get; set; }
            public ResponseCode responseCode { get; set; }
        }

        public class CodeDescription
        {
            [JsonProperty("code")]
            public string Code { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
        }

        public class StateInfo
        {
            [JsonProperty("stateCode")]
            public string stateCode { get; set; }

            [JsonProperty("state")]
            public string state { get; set; }
        }
   
        public class Form
        {
            public string coverageTrigger { get; set; }
            public string effectiveDate { get; set; }
            public string expirationDate { get; set; }
            public string formName { get; set; }
            public string formNumber { get; set; }
            public string formType { get; set; }
            public string issueCompany { get; set; }
            public string state { get; set; }
        }

        public class ResponseCode
        {
            public int messageCode { get; set; }
            public string message { get; set; }
            public string status { get; set; }
        }
    }
}