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
        SDNAppsEntities _se = new SDNAppsEntities();

        //public AutoController(SDNAppsEntities se)
        //{
        //    _se = se;
        //}


        public ActionResult List(int personid)
        {
            ListViewModel lvm = new ListViewModel(_se.Autos.Where(m => m.WhosCar == personid).ToList(),_se.People.Where(m => m.ID == personid).FirstOrDefault());

            return View(lvm);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddViewModel avm)
        {
            Auto a = new Auto();

            a.AutoName = avm.AutoName;
            a.WhosCar = avm.PersonID;

            _se.Autos.Add(a);
            _se.SaveChanges();

            return View(avm);
        }


    }
}
