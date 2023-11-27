using MedProSC.Feature.ManualForms.Controllers;
using MedProSC.Feature.ManualForms.Repositories;
using MedProSC.Feature.ManualForms.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using System.Web.Mvc;
using RestSharp;

namespace MedProSC.Feature.ManualForms
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Replace(ServiceDescriptor.Transient<IManualFormsService, ManualFormsService>());
            serviceCollection.Replace(ServiceDescriptor.Transient<IManualFormsRepository, ManualFormsRepository>());          
            serviceCollection.Replace(ServiceDescriptor.Transient<IRestClient, RestClient>());
            serviceCollection.AddTransient<ManualFormsController>();
        }
    }
}