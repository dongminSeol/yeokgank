using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace yeokgank.Entities.Apartment
{
    [Table("T_ApartmentTradeData")]
    public class ApartmentTrade
    {
        [Key]
        public string TradeCode { get; set; }
        public string ApartmentName { get; set; }
        public string DealAmount { get; set; }
        public string BuildYear { get; set; }
        public string DealYear { get; set; }
        public string RoadName { get; set; }
        public string RoadName_Bonbun { get; set; }
        public string RoadName_Bubun { get; set; }
        public string RoadName_SigunguCode { get; set; }
        public string RoadName_Seq { get; set; }
        public string RoadName_BasementCode { get; set; }
        public string RoadName_Code { get; set; }
        public string Dong { get; set; }
        public string Bonbun { get; set; }
        public string Bubun { get; set; }
        public string SigunguCode { get; set; }
        public string EubmyundongCode { get; set; }
        public string LandCode { get; set; }
        public string DealMonth { get; set; }
        public string DealDay { get; set; }
        public string ManageCode { get; set; }
        public string AreaforExclusiveUse { get; set; }
        public string Jibun { get; set; }
        public string RegionalCode { get; set; }
        public string Floor { get; set; }
        public string CancelDeal_Type { get; set; }
        public string CancelDeal_Day { get; set; }
        public string State { get; set; }
        public string RegDate { get; set; }
    }
}
