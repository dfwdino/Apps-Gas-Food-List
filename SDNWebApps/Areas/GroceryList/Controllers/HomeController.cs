using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using SDNWebApps.Areas.GroceryList.Models.Home;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    public class HomeController : Controller
    {
        SDNAppsEntities sdnApps = new SDNAppsEntities();

        public ActionResult Index(bool showAll=false)
        {
            IQueryable<Item> gitems = sdnApps.Items;
            Item item = new Item();
            var itemsVM = new ViewItemsVM();

            if (showAll)
            {
                ViewBag.Title = "All Items";
                itemsVM.ShowAll = showAll;
            }
            else
            { 
                gitems = gitems.Where(m => m.Have == showAll);
                ViewBag.Title = "Need Items";
            }

            itemsVM.Items = gitems.OrderBy(m => m.Name).ToList();


            return View(itemsVM);
        }


    }
}
