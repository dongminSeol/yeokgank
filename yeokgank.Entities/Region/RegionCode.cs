using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yeokgank.Entities.Region
{
    [Table("T_RegionCode")]
    public class RegionCode
    {
        [Key]
        public long Seq { get; set; }
        public string AD_H_CD { get; set; }
		public string AD_M_CD { get; set; }
		public string AD_S_CD { get; set; }
		public string AD_T_CD { get; set; }
		public string AD_H_NM { get; set; }
		public string AD_M_NM { get; set; }
		public string AD_S_NM { get; set; }
		public string AD_T_NM { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }
		public string State { get; set; }

	}
}
