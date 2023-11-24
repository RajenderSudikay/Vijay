using System;
using Sitecore.Data.Items;

namespace MedProSC.Feature.ManualForms.Repositories
{
    public interface IManualFormsRepository
    {
        Item GetApiSettingItemBasedOnEnvironment();

    }
}