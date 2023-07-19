using Sitecore.Data;

namespace MedProSC.Project.Website
{
    public class Templates
    {
        public struct HeaderTemplate
        {
            public static readonly ID TemplateID = new ID("{56716662-0509-45AA-91A4-C1352ABA90B8}");

            public struct Fields
            {
                public static readonly ID HeaderTitle = new ID("{108CDDAB-5261-42BA-A76A-6E9A20E40143}");
                public static readonly ID FormBuilderTitle = new ID("{E4289044-FB46-4472-877B-6E001E579B17}");
                public static readonly ID BundleHistoryTitle = new ID("{F7F28687-C70C-41B5-9AA5-81B9EDFBB856}");
            }
        }
    }
}