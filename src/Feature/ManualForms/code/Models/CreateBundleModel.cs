using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedProSC.Feature.ManualForms.Models
{
    public class CreateBundleModel
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Form
        {
            public string formName { get; set; }
            public string formId { get; set; }
        }

        public class CreateBundle
        {
            public string firstNamedInsured { get; set; }
            public string forms { get; set; }
            public string formType { get; set; }
            public string insuredScheduleData { get; set; }
            public string policyNumber { get; set; }
            public string policyEffectiveDate { get; set; }
            public string transactionType { get; set; }
            public string description { get; set; }
            public string createdBy { get; set; }
            public string state { get; set; }
            public DateTime modifiedOnDate { get; set; }
            public HttpPostedFileBase xmlFile { get; set; }
        }

        public class CreateBundlePostRequest
        {
            public string firstNamedInsured { get; set; }
            public List<Form> forms { get; set; }
            public string formType { get; set; }
            public string insuredScheduleData { get; set; }
            public string policyNumber { get; set; }
            public string policyEffectiveDate { get; set; }
            public string transactionType { get; set; }
            public string description { get; set; }
            public string createdBy { get; set; }
            public string state { get; set; }
            public DateTime modifiedOnDate { get; set; }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class ResponseCode
        {
            public int messageCode { get; set; }
            public string message { get; set; }
            public string status { get; set; }
        }

        public class CreateBundleResponseRoot
        {
            public int formBundleId { get; set; }
            public string documentId { get; set; }
            public ResponseCode responseCode { get; set; }
        }

    }
}