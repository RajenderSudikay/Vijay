using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}