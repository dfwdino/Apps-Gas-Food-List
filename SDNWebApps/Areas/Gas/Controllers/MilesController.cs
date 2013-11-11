using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SDNWebApps.Areas.Gas.Models.Miles;

namespace SDNWebApps.Areas.Gas.Controllers
{
    public class MilesController : Controller
    {
        SDNAppsEntities ae = new SDNAppsEntities();

        public ActionResult List(int autoID)
        {
            Models.Miles.ListViewModel lmvModel = new Models.Miles.ListViewModel(ae.Gallons.Where(m => m.AutoID == autoID).OrderBy(m => m.TotalMiles).ToList());
            lmvModel.autoID = autoID;
            return View(lmvModel);
        }

       

        public ActionResult Add(int autoID)
        {
            Models.Miles.AddViewModel lmvModel = new Models.Miles.AddViewModel(autoID);
            ViewBag.Title = "Add";

            return View(lmvModel);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel addviewmodel)
        {
            //if (ModelState.IsValid)
            //{

                Gallon gallon = new Gallon();

                gallon.AutoID = addviewmodel.AutoID;
                gallon.TotalMiles = addviewmodel.TotalMiles;
                gallon.TotalGallons = addviewmodel.TotalGallons;
                gallon.DrivenMiles = addviewmodel.DrivenMiles;
                gallon.TotalPrice = addviewmodel.TotalPrice;
                gallon.TankFilled = addviewmodel.TankFilled;

                if (addviewmodel.GasDate.HasValue)
                    gallon.GasDate = addviewmodel.GasDate;
                else
                    gallon.GasDate = DateTime.Now;

                ae.Gallons.Add(gallon);
                int NumberOfChanges = ae.SaveChanges();
            //}

            ViewBag.Title = "Edit";
                return View(addviewmodel);
        }

    }
}
