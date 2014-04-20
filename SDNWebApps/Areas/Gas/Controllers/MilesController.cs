using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SDNWebApps.Areas.Gas.Models.Miles;

namespace SDNWebApps.Areas.Gas.Controllers
{
    public class MilesController : Controller
    {
        SDNAppsEntities ae = new SDNAppsEntities();

        public ActionResult List(int id)
        {
            ListViewModel lmvModel = new Models.Miles.ListViewModel(ae.Gallons.Where(m => m.AutoID == id).OrderBy(m => m.TotalMiles).ToList());

            lmvModel.PersonID = ae.Autos.First(m => m.ID == id).Person.ID.ToString();
            lmvModel.autoID = id;
            lmvModel.AutoName = ae.Autos.First(m => m.ID == id).AutoName;

            return View(lmvModel);
        }

       

        public ActionResult Add(int id)
        {
            Models.Miles.AddViewModel lmvModel = new Models.Miles.AddViewModel(id);
            ViewBag.Title = "Add";

            lmvModel.TotalGallons = null;
            lmvModel.TotalMiles = null;
            lmvModel.DrivenMiles = null;

            return View(lmvModel);
        }

        [HttpPost]
        public ActionResult Add(AddViewModel addviewmodel)
        {
            //if (ModelState.IsValid)
            //{

                Gallon gallon = new Gallon
                {
                    AutoID = addviewmodel.AutoID,
                    TotalMiles = (int) (addviewmodel.TotalMiles ?? 0),
                    TotalGallons = addviewmodel.TotalGallons ?? 0,
                    DrivenMiles = addviewmodel.DrivenMiles ?? 0,
                    TotalPrice = addviewmodel.TotalPrice,
                    TankFilled = addviewmodel.TankFilled
                };

            if (addviewmodel.GasDate.HasValue)
                gallon.GasDate = addviewmodel.GasDate;
            else
                gallon.GasDate = DateTime.Now;

                ae.Gallons.Add(gallon);
                int NumberOfChanges = ae.SaveChanges();
            //}

            //ViewBag.Title = "Edit";

            List<Gallon> test = ae.Gallons.Where(m => m.AutoID == addviewmodel.AutoID).ToList();

            ListViewModel lvm = new ListViewModel(test);

            return View("List", lvm);
        }

    }
}
