using System.ComponentModel.DataAnnotations;

namespace yeokgank.ViewModel.Region
{
    public class RegionViewModel
    {
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "Lat")]
        public string Lat { get; set; }
        [Display(Name = "Lng")]
        public string Lng { get; set; }
        [Display(Name = "RegionCode")]
        public string RegionCode { get; set; }
    }
}
