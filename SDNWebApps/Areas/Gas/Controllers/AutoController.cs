using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SDNWebApps.Areas.Gas.Models.Auto;

namespace SDNWebApps.Areas.Gas.Controllers
{
    public class AutoController : Controller
    {
        //
        // GET: /Gas/Auto/

        public ActionResult List(int personid)
        {
            SDNAppsEntities se = new SDNAppsEntities();
          
            ListViewModel lvm = new ListViewModel(se.Autos.Where(m => m.WhosCar == personid).ToList());

            return View(lvm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddViewModel avm)
        {

            return View();
        }


    }
}
