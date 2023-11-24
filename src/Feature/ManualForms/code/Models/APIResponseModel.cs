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
    }
}