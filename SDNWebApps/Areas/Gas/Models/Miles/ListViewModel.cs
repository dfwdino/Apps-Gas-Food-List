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
            autoID = gallons.Count >0 ? gallons[0].Auto.ID : 0;
            personID = gallons.Count > 0 ? gallons[0].Auto.Person.ID : 0;
        }

        public  int autoID { get; set; }
        public int personID { get; set; }
        public List<Gallon> Gallons { get; set; }

    }

    

}