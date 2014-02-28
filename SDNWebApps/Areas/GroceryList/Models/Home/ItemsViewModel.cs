using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.WebPages.Html;
using HtmlHelper = System.Web.Mvc.HtmlHelper;
using System.Web.Routing;

namespace SDNWebApps.Areas.GroceryList.Models.Home
{
    public class ItemsViewModel
    {
        public ItemsViewModel()
        {
            
        }

        public ItemsViewModel(ItemsViewModel itemsViewModel)
        {
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public Store Store { get; set; }

        public string SelectedItemId { get; set; }

        public MvcHtmlString ListStores
        {

            get
            {
                SDNAppsEntities test = new SDNAppsEntities();
                var ddl =test.Stores.Select(m => new {m.ID, m.StoreName})
                    .ToList()
                    .Select(m => new System.Web.Mvc.SelectListItem {Text = m.StoreName, Value = m.ID.ToString()})
                    .ToList();

                HtmlHelper htmlHelper = new HtmlHelper(new ViewContext(),null);

                return htmlHelper.DropDownList("name", ddl, "select");
            }
        }

        public List<System.Web.Mvc.SelectListItem> ListToUse { get; set; }
       



    }
}