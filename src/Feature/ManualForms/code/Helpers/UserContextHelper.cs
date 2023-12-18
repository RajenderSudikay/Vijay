using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedProSC.Feature.ManualForms.Helpers
{
    public class UserContextHelper
    {
        public static string GetEnvironment()
        {
            return System.Configuration.ConfigurationManager.AppSettings["env:define"];
        }
    }
}