using System;
using Sitecore.Data.Items;

namespace MedProSC.Feature.ManualForms.Repositories
{
    public interface IStateRepository
    {
        Item GetApiSettingItemBasedOnEnvironment();

    }
}