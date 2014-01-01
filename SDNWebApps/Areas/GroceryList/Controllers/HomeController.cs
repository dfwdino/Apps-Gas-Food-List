using System.Linq;
using System.Web.Mvc;

namespace SDNWebApps.Areas.GroceryList.Controllers
{
    public class HomeController : Controller
    {
        SDNAppsEntities sdnApps = new SDNAppsEntities();

        public ActionResult Index()
        {
            var gitems = sdnApps.Items.Where(m => m.Have);

            return View(gitems);
        }
        [HttpPost]
        public JsonResult DeleteItem(int itemID)
        {
            var ditem = sdnApps.Items.First(m => m.ID == itemID);

            sdnApps.Items.Remove(ditem);
            //sdnApps.SaveChanges();

            return Json("Record deleted successfully!");

        }


    }
}
