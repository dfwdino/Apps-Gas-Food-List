using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace SDNWebApps.Areas.GroceryList.Models.Home
{
    public class ItemsViewModel
    {
        public ItemsViewModel(ItemsViewModel itemsViewModel)
        {
            ItemName = itemsViewModel.ItemName;
            Price = itemsViewModel.Price > 0.00 ? itemsViewModel.Price : 0.00;
            //StoreID = itemsViewModel.StoreID;
            StoreName = itemsViewModel.StoreName;
        }

        public string ItemName { get; set; }
        public double Price { get; set; }
        //public Guid StoreID { get; set; }
        public string StoreName { get; set; }

        

    }
}