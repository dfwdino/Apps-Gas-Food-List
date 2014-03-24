using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDNWebApps.Areas.Tasks.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Tasks/Home/

        SDNAppsEntities sdnApps = new SDNAppsEntities();

        public ActionResult Index(bool showAll = false)
        {
            IQueryable<Task> gtasks = sdnApps.Tasks;
            Item item = new Item();


            if (showAll)
            {
                ViewBag.Title = "All Tasks";
                
            }
            else
            {
                gtasks = gtasks.Where(m => m.Done == showAll);
                ViewBag.Title = "Tasks To-Do";
            }

            return View(gtasks.ToList());
        }

    }
}
