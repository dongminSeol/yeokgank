using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace yeokgank.Entities.Apartment
{
    [Table("T_ApartmentList")]
    public class ApartmentList
    {
        [Key]
        public string KaptCode { get; set; }
        public string KaptName { get; set; }
        public string BjdCode { get; set; }
        public string RegDate { get; set; }
    }
}
