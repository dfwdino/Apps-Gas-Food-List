using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace SDNWebApps.Areas.Gas.Models.Auto
{
    public class AddViewModel
    {
        public AddViewModel()
        {
            
        }

        public AddViewModel(SDNWebApps.Auto auto)
        {
            SDNAppsEntities se = new SDNAppsEntities();

            SDNWebApps.Auto a = new SDNWebApps.Auto();

            a.AutoName = auto.AutoName;
            a.WhosCar = PersonID;

            se.Autos.Add(auto);
            se.SaveChanges();


        }

        public List<SDNWebApps.Person> Person { get; set; }
        public string AutoName { get; set; }
        public int PersonID { get; set; }
        public string Name { get; set; }
    }

   
}