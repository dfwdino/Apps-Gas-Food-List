using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDNWebApps.Areas.Gas.Models.Auto
{
    public class ListViewModel
    {
        public ListViewModel(List<SDNWebApps.Auto> a,SDNWebApps.Person p)
        {
            Auto = a;
            Person = p;
            
        }

        public List<SDNWebApps.Auto> Auto { get; set; }
        public SDNWebApps.Person Person { get; set; }





    }
}