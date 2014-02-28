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

            if (!showAll)
                gitems = gitems.Where(m => m.Have == showAll);

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

        public ActionResult ListStores()
        {
            IQueryable<Store> gitems = sdnApps.Stores;


            return View(gitems);
        }

        public ActionResult AddStore()
        {
            var newStore = new Store();

            return View(newStore);
        }

        [HttpPost]
        public ActionResult AddStore(string storeName)
        {
            var newStore = new Store();

            newStore.StoreName = storeName;

            sdnApps.Stores.Add(newStore);
            sdnApps.SaveChanges();

            return View(newStore);

        }

        public ActionResult AddItem()
        {
            var newItem = new Models.Home.ItemsViewModel();

            newItem.ListToUse =
                new SDNAppsEntities().Stores.OrderBy(m => m.StoreName).Select(m =>
                    new SelectListItem { Value = SqlFunctions.StringConvert((double)m.ID).Trim(), Text = m.StoreName }).ToList();

            return View(newItem);
        }
        
        [HttpPost]
        public JsonResult AddItem(string name, string price, int storeID)
        {
            if (price.IsNullOrWhiteSpace())
                price = "0";

            var newItem = new Item { Name = name, Price = Convert.ToDecimal(price), StoreID = storeID, Have = false };

            sdnApps.Items.Add(newItem);
            sdnApps.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public JsonResult DeleteItem(int itemID)
        {
            var ditem = sdnApps.Items.First(m => m.ID == itemID);

            sdnApps.Items.Remove(ditem);
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");

        }
        public JsonResult DeleteStore(int itemID)
        {
            var ditem = sdnApps.Stores.First(m => m.ID == itemID);

            sdnApps.Stores.Remove(ditem);
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");

        }

        [HttpPost]
        public JsonResult GotItem(int itemID, bool haveItem = false)
        {
            var gotItem = sdnApps.Items.First(m => m.ID == itemID);

            gotItem.Have = haveItem;
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");
        }

    }
}
