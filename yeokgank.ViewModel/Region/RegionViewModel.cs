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

        [Display(Name = "AD_H_NM")]
        public string AD_H_NM { get; set; }
        [Display(Name = "AD_M_NM")]
        public string AD_M_NM { get; set; }
        [Display(Name = "AD_S_NM")]
        public string AD_S_NM { get; set; }
        [Display(Name = "AD_T_NM")]
        public string AD_T_NM { get; set; }

        [Display(Name = "AD_H_CD")]
        public string AD_H_CD { get; set; }
        [Display(Name = "AD_M_CD")]
        public string AD_M_CD { get; set; }
        [Display(Name = "AD_S_CD")]
        public string AD_S_CD { get; set; }
        [Display(Name = "AD_T_CD")]
        public string AD_T_CD { get; set; }
    }
}
