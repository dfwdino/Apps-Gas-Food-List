using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.UI.WebControls;
using System.Web.WebPages.Html;
using HtmlHelper = System.Web.Mvc.HtmlHelper;
using System.Web.Routing;

namespace SDNWebApps.Areas.GroceryList.Models.Home
{
    public class ViewItemsVM
    {
        public ViewItemsVM()
        {

        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Store { get; set; }
        public bool ShowAll { get; set; }
    }
}