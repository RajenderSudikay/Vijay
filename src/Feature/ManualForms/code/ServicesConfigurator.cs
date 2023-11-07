﻿using MedProSC.Feature.ManualForms.Controllers;
using MedProSC.Feature.ManualForms.Repositories;
using MedProSC.Feature.ManualForms.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sitecore.DependencyInjection;
using System.Web.Mvc;

namespace MedProSC.Feature.ManualForms
{
    public class ServicesConfigurator : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.Replace(ServiceDescriptor.Transient<IStateService, StateService>());
            serviceCollection.Replace(ServiceDescriptor.Transient<IStateRepository, StateRepository>());
            serviceCollection.AddTransient<ManualFormsController>();
        }
    }
}