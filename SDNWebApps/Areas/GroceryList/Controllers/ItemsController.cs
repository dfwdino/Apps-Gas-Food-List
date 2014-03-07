using System;
using System.Collections.Generic;
using System.Data.Objects.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    public class ItemsController : Controller
    {
        SDNAppsEntities sdnApps = new SDNAppsEntities();

        [HttpPost]
        public JsonResult GotItem(int itemID, bool haveItem = false)
        {
            var gotItem = sdnApps.Items.First(m => m.ID == itemID);

            gotItem.Have = haveItem;
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");
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

        var newItem = sdnApps.Items.FirstOrDefault(m => m.Name == name);

        if (newItem == null)
            newItem = new Item { Name = name, Price = Convert.ToDecimal(price), StoreID = storeID, Have = false };
        else
            newItem.Have = false;

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
}
}
