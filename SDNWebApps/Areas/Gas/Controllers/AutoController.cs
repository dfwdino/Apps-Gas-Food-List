﻿using System;
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

        public ActionResult List(int id)
        {
            ListViewModel lvm = new ListViewModel(_se.Autos.Where(m => m.WhosCar == id).ToList(),
                                                    _se.People.FirstOrDefault(m => m.ID == id));

            

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
