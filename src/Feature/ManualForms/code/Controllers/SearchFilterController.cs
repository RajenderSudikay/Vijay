using MedProSC.Feature.ManualForms.Models;
using Sitecore.IO;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static MedProSC.Feature.ManualForms.Templates;
using static Sitecore.Shell.UserOptions.HtmlEditor;

namespace MedProSC.Feature.ManualForms.Controllers
{
    public class SearchFilterController : Controller
    {
        // GET: ManualForms
        public ActionResult SearchFilter()
        {
            var searchfilterModel = new SearchFilter();
            var searchfilterDataSource = RenderingContext.Current.Rendering.DataSource;
            if (!string.IsNullOrWhiteSpace(searchfilterDataSource))
            {
                var searchfilterDataSoureItem = Sitecore.Context.Database.GetItem(searchfilterDataSource, Sitecore.Context.Language);

                if (searchfilterDataSoureItem != null)
                {
                    searchfilterModel.SearchForms = searchfilterDataSoureItem.Fields[SearchFormTemplate.Fields.SearchForms].Value;
                    searchfilterModel.ClicktoaddForm = searchfilterDataSoureItem.Fields[SearchFormTemplate.Fields.ClicktoaddForm].Value;
                    searchfilterModel.SearchbyForm = searchfilterDataSoureItem.Fields[SearchFormTemplate.Fields.SearchbyForm].Value;
                    searchfilterModel.SearchbyName = searchfilterDataSoureItem.Fields[SearchFormTemplate.Fields.SearchbyName].Value;
                    searchfilterModel.CoverageType = searchfilterDataSoureItem.Fields[SearchFormTemplate.Fields.CoverageType].Value;
                    searchfilterModel.ClearFilterButton = searchfilterDataSoureItem.Fields[SearchFormTemplate.Fields.ClearFilterButton].Value;


                }
            }

            return View("~/Views/ManualForms/SearchFilter.cshtml", searchfilterModel);
        }
    }
}