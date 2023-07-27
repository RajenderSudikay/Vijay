using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedProSC.Feature.ManualForms
{
    public class Templates
    {
        public struct LoadFormTemplate
        {
            public static readonly ID TemplateID = new ID("{8D1D68DB-85E5-497E-93BA-74ECB94F5555}");

            public struct Fields
            {
                public static readonly ID LoadFormTitle = new ID("{BB7D9816-F8BE-4534-AB5D-4560BE78E222}");
                public static readonly ID IssueLabel = new ID("{0ABDA229-B173-4D73-8EFD-4B6A3B3AA951}");
                public static readonly ID StateLabel = new ID("{91060D05-F448-49FD-BF41-827465F5B758}");
                public static readonly ID DateLabel = new ID("{D012CC77-7129-4D5D-ADD3-F2FE5A2B0A00}");
                public static readonly ID FormsTypeLabel = new ID("{A32D9926-96C7-40EE-BA42-B5D5BA7DA7FE}");
                public static readonly ID LoadFormButtonText = new ID("{DDDCA1C0-A81E-47CA-8881-86E9B8708903}");

            }
        }
        public struct SearchFormTemplate
        {
            public static readonly ID TemplateID = new ID("{EFDCEC51-1A09-4AB1-884D-940CF93014D7}");

            public struct Fields
            {
                public static readonly ID SearchForms = new ID("{40E44688-7825-440C-B481-F7E65BF620B1}");
                public static readonly ID ClicktoaddForm = new ID("{C6A970F8-F447-46FD-AE5C-29840B6ACECC}");
                public static readonly ID SearchbyForm = new ID("{C277E3FD-DA04-4959-825F-98B2CD79BFCA}");
                public static readonly ID SearchbyName = new ID("{6D47A52F-33E5-4800-A578-D5FD8F014829}");
                public static readonly ID CoverageType = new ID("{2F90642A-B638-4B9F-B388-156561C9B592}");
                public static readonly ID ClearFilterButton = new ID("{493FC9D4-8302-4129-8D7E-E4524CF01CFA}");

            }
        }
    }
}