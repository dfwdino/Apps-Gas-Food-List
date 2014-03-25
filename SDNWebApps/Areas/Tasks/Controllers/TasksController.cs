using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SDNWebApps.Areas.Tasks.Controllers
{
    public class TasksController : Controller
    {
        SDNAppsEntities sdnApps = new SDNAppsEntities();

        [HttpPost]
        public JsonResult GotTask(int taskID, bool done = false)
        {
            var gotItem = sdnApps.Tasks.First(m => m.ID == taskID);

            gotItem.Done = done;
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");
        }

        public ActionResult AddTask()
        {
            

            return View(new Task());
        }

        [HttpPost]
        public JsonResult AddTask(string title, string duedate)
        {
            var newTask = sdnApps.Tasks.FirstOrDefault(m => m.Title == title);
            DateTime? dueDate = null;

            if (duedate != string.Empty)
                dueDate = Convert.ToDateTime(duedate);

            if (newTask == null)
                newTask = new Task { Title = title, DueDate = dueDate, Done = false };
            else
            {
                newTask.Done = false;
                newTask.DueDate = Convert.ToDateTime(duedate);
            }

            sdnApps.Tasks.Add(newTask);
            sdnApps.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        public JsonResult DeleteItem(int taskID)
        {
            var dtask = sdnApps.Tasks.First(m => m.ID == taskID);

            sdnApps.Tasks.Remove(dtask);
            sdnApps.SaveChanges();

            return Json("Record deleted successfully!");

        }

    }
}
