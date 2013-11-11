using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDNWebApps.Areas.Gas.Models.Auto
{
    public class ListViewModel
    {
        public ListViewModel(List<SDNWebApps.Auto> a)
        {
            Auto = a;
            PersonName = a == null ? "" : a.FirstOrDefault().Person.PersonName;
        }

        public List<SDNWebApps.Auto> Auto { get; set; }
        public string PersonName {get; set; }




    }
}