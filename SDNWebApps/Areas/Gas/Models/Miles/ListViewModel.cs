using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDNWebApps.Areas.Gas.Models.Miles
{
    public class ListViewModel
    {
        public ListViewModel(List<Gallon> gallons)
        {
            Gallons = gallons;
        }

        public  int autoID { get; set; }
        public int personName { get; set; }
        public List<Gallon> Gallons { get; set; }

    }

    

}