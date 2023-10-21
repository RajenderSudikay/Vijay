using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using MedProSC.Foundation.Security.Repositories;
using MedProSC.Foundation.Security.Services;

namespace MedProSC.Foundation.Security
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Replace(ServiceDescriptor.Transient<IOktaSettingService, OktaSettingService>());
            serviceCollection.Replace(ServiceDescriptor.Transient<IOktaSettingRepository, OktaSettingRepository>());
        }
    }
}