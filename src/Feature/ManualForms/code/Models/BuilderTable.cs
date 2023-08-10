using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedProSC.Feature.ManualForms.Models
{
    public class BuilderTable
    {
        public string FormNumber { get; set; }

        public string FormName { get; set; }
        public string Occurences { get; set; }
        public string ClaimsMade { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
    }
}
