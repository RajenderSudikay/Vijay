using Sitecore.Data.Items;

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
        public string ResultsPerPage { get; set; }
        public string ShowPageNumber { get; set; }
        public Item[] PageNumbers { get; set; }
    }
}
