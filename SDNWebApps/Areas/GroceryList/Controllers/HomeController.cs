using System;
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

            if (showAll)
            {
                ViewBag.Title = "All Items";
            }
            else
            { 
                gitems = gitems.Where(m => m.Have == showAll);
                ViewBag.Title = "Need Items";
            }

            //a better way of doing this
            var itemsVM = gitems.Select(m => new ViewItemsVM
            {
                ID = m.ID,
                Name = m.Name,
                Store = m.Store.StoreName,
                Price = SqlFunctions.StringConvert((decimal) m.Price)

            });

            return View(itemsVM.ToList());
        }


    }
}
