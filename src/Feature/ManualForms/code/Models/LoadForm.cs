using System.Collections.Generic;
using System.Web.Mvc;
using static MedProSC.Feature.ManualForms.Models.APIResponseModel;

namespace MedProSC.Feature.ManualForms.Models
{
    public class LoadForm
    {
        public string LoadFormTitle { get; set; }
        public string IssueLabel { get; set; }
        public string StateLabel { get; set; }
        public string DateLabel { get; set; }
        public string FormsTypeLabel { get; set; }
        public string LoadFormButtonText { get; set; }
        public IList<SelectListItem> StateList { get; set; }
        public IList<SelectListItem> IssueCompanyList { get; set; }
        public IList<SelectListItem> FormsTypeList { get; set; }
        public LoadFormsRoot LoadForms { get; set; }
    }

    public class LoadFormSearchModel
    {
        public string issueCompany { get; set; }
        public string state { get; set; }
        public string formDate { get; set; }
        public string formType { get; set; }
        public string apiQueryString { get; set; }

    }
}