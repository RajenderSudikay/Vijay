using MedProSC.Project.Website.Models;
using Sitecore.Mvc.Presentation;
using System.Web.Mvc;

namespace MedProSC.Project.Website.Controllers
{
    using static Templates;

    public class HeaderController : Controller
    {       
        public ActionResult Header()
        {
            var headerModel = new HeaderModel();
            var headerDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(headerDataSource))
            {
                var headerDataSoureItem = Sitecore.Context.Database.GetItem(headerDataSource, Sitecore.Context.Language);

                if (headerDataSoureItem != null)
                {
                    headerModel.HeaderTitle = headerDataSoureItem.Fields[HeaderTemplate.Fields.HeaderTitle].Value;
                    headerModel.FormBuilderTitle = headerDataSoureItem.Fields[HeaderTemplate.Fields.FormBuilderTitle].Value;
                    headerModel.BundleHistoryTitle = headerDataSoureItem.Fields[HeaderTemplate.Fields.BundleHistoryTitle].Value;
                }
            }
            return View("~/Views/Shared/Header.cshtml", headerModel);
        }
    }
}