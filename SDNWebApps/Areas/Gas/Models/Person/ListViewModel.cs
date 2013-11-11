using System.Collections.Generic;

namespace SDNWebApps.Areas.Gas.Models.Person
{
    public class ListViewModel
    {
        public ListViewModel(List<SDNWebApps.Person> persons)
        {
            Persons = persons;
        }

        public List<SDNWebApps.Person> Persons { get; set; }

    }

    

}