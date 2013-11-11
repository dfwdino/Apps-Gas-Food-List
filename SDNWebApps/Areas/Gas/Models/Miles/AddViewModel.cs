using System;

namespace SDNWebApps.Areas.Gas.Models.Miles
{
    public class AddViewModel
    {

        public AddViewModel()
        {
           
        }

        public AddViewModel(int autoID)
        {
            AutoID = autoID;
        }

        public AddViewModel(Gallon gallon)
        {
            AutoID =       gallon.AutoID;
            TotalMiles =   gallon.TotalMiles;
            TotalGallons = gallon.TotalGallons;
            DrivenMiles  = gallon.DrivenMiles;
            TotalPrice =   gallon.TotalPrice;
            GasDate =      gallon.GasDate;
            TankFilled =   gallon.TankFilled;

        }

        public int AutoID { get; set; }
        public int PersonID { get; set; }
        public int TotalMiles  { get; set; }
        public double TotalGallons  { get; set; }
        public int DrivenMiles { get; set; }
        public decimal? TotalPrice  { get; set; }
        public DateTime? GasDate  { get; set; }
        public bool TankFilled { get; set; }


    }
}