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
        public struct BuildTableTemplate
        {
            public static readonly ID TemplateID = new ID("{AAB24A43-F77E-4FA2-8156-747A8A8AC206}");

            public struct Fields
            {
                public static readonly ID FormNumber = new ID("{073F88EB-C821-4F22-B74A-65E3BE9AE332}");
                public static readonly ID FormName = new ID("{E31AEE71-A1E7-4D33-B2FC-655D74E74FA4}");
                public static readonly ID Occurences = new ID("{FD60EBA6-F188-4BC9-8D98-069C606169EB}");
                public static readonly ID ClaimsMade = new ID("{1B34AB7C-CD18-4A95-907A-56E21E897936}");
                public static readonly ID EffectiveDate = new ID("{844B5B40-EFE7-4269-BEE6-718635AA6079}");
                public static readonly ID ExpirationDate = new ID("{5DC8112A-F8AB-4529-ADBE-346D6F47C5D8}");
                public static readonly ID ResultsPerPage = new ID("{810F559B-B04C-42CC-B2A8-7BEFE6CF78BD}");
                public static readonly ID PageNumers = new ID("{105CE772-4421-4B22-9A53-6FCD6503B44E}");
                public static readonly ID ShowPageNumber = new ID("{87505491-4B25-4759-AE70-B1DCCAE606D5}");

            }
        }

        public struct MyBundleTemplate
        {
            public static readonly ID TemplateID = new ID("{2DF7734A-A4EE-47A9-ACC0-346457A7ACB1}");

            public struct Fields
            {
                public static readonly ID MyBundleTitle = new ID("{1F889DE2-DB08-4611-9E5A-D5965EC495C7}");
                public static readonly ID FormNumber = new ID("{823E342B-3E20-46FF-8F9E-7921D53B2930}");
                public static readonly ID FormName = new ID("{1DB7A97E-491C-4082-9702-69BD067CBDA9}");
                public static readonly ID PolocyNumber = new ID("{0B81790B-FA07-49E8-84B2-3A8C63F13D2D}");
                public static readonly ID TransactionType = new ID("{1448EED6-FDC2-43FF-9BBE-7966F40C830E}");
                public static readonly ID CreateBundle = new ID("{2AC60602-1AEC-4FEE-8986-A6F1DA24CB6F}");
                public static readonly ID Description = new ID("{39D3F758-49DB-483A-AC25-F8A39AA4D46F}");
                public static readonly ID FirstNamedInsured = new ID("{29D0B6AB-0832-42EF-BC9A-2A23931C3910}");

            }
        }
    }
}