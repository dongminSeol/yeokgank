using Newtonsoft.Json;
using System.Collections.Generic;
using yeokgank.DataScheduler.Services;
namespace yeokgank.DataScheduler.Model
{
    public class ApartmentTradeData
    {
        public Response response { get; set; }

        public class Response
        {
            public Header header { get; set; }
            public Body body { get; set; }
        }
        public class Header
        {
            public string resultCode { get; set; }
            public string resultMsg { get; set; }
        }
        public class Body
        {
            public Items items { get; set; }
            public int numOfRows { get; set; }
            public int pageNo { get; set; }
            public int totalCount { get; set; }
        }
        public class Items
        {
            [JsonConverter(typeof(SingleOrArrayConverter<Item>))]
            public List<Item> item { get; set; }
        }

        public class Item
        {
            public string 거래금액 { get; set; }

            public string 건축년도 { get; set; }

            public string 년 { get; set; }

            public string 도로명 { get; set; }

            public string 도로명건물본번호코드 { get; set; }

            public string 도로명건물부번호코드 { get; set; }

            public string 도로명시군구코드 { get; set; }

            public string 도로명일련번호코드 { get; set; }

            public string 도로명지상지하코드 { get; set; }

            public string 도로명코드 { get; set; }

            public string 법정동 { get; set; }

            public string 법정동본번코드 { get; set; }

            public string 법정동부번코드 { get; set; }

            public string 법정동시군구코드 { get; set; }

            public string 법정동읍면동코드 { get; set; }

            public string 법정동지번코드 { get; set; }

            public string 아파트 { get; set; }

            public string 월 { get; set; }

            public string 일 { get; set; }

            public string 일련번호 { get; set; }

            public string 전용면적 { get; set; }

            public string 지번 { get; set; }

            public string 지역코드 { get; set; }

            public string 층 { get; set; }

            public string 해제사유발생일 { get; set; }

            public string 해제여부 { get; set; }
        }
    }

}
