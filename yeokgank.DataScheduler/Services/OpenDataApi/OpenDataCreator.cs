using yeokgank.DataScheduler.Services.Apartments;
namespace yeokgank.DataScheduler.Services.OpenDataApi
{
    public class OpenDataCreator 
    {
        /// <summary>
        ///  국토교통부_아파트 기본정보 조회
        /// </summary>
        /// <param name="settings">요청변수</param>
        public static OpenData ApartmentBasicInfo(Settings settings)
        {
            return new ApartmentBasicInfo();
        }
        /// <summary>
        /// 국토교통부_아파트매매 실거래 상세 자료
        /// </summary>
        /// <param name="settings">요청변수</param>
        public static OpenData ApartmentTradeInfo(Settings settings)
        {
            return new ApartmentTradeInfo(settings);
        }
        /// <summary>
        /// 국토교통부_공동주택 단지 목록제공 - 시군구 아파트 목록
        /// </summary>
        /// <param name="settings">요청변수</param>
        public static OpenData ApartmentSigunguInfo(Settings settings)
        {
            return new ApartmentSigunguInfo(settings);
        }
        /// <summary>
        /// 국토교통부_아파트 상세정보 조회
        /// </summary>
        /// <param name="settings">요청변수</param>
        public static OpenData ApartmentDetailInfo(Settings settings)
        {
            return new ApartmentDetailInfo(settings);
        }
    }
}
