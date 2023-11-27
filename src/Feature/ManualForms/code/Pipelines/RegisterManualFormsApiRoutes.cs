using Sitecore.Pipelines;
using System.Web.Mvc;
using System.Web.Routing;


namespace MedProSC.Feature.ManualForms.Pipelines
{
    public class RegisterManualFormsApiRoutes : Sitecore.Mvc.Pipelines.Loader.InitializeRoutes
    {
        protected override void RegisterRoutes(RouteCollection routes, PipelineArgs args)
        {
            routes.MapRoute("ManualFormsApi", "manualformsapi/{action}", new
            {
                controller = "ManualForms",
                action = "GetLoadForms",
            }, namespaces: new[] { "MedProSC.Feature.ManualForms.Controllers" });

        }
    }
}