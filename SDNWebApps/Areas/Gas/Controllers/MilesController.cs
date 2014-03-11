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
