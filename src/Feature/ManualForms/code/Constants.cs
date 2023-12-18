namespace MedProSC.Feature.ManualForms
{
    public class Constants
    {
        public struct APIHeaders
        {
            public static readonly string Client_id = "client_id";
            public static readonly string Client_secret = "client_secret";
            public static readonly string XCorrelationId = "X-Correlation-Id";
            public static readonly string Accept = "Accept";
            public static readonly string RequestAcceptType = "application/json";          
        }

        public struct Common
        {          
            public static readonly string claim_preferredusername = "preferred_username";
        }
    }
}