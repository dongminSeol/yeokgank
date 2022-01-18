using Newtonsoft.Json;
using System.Collections.Generic;
using yeokgank.DataScheduler.Services;

namespace yeokgank.DataScheduler.Model
{
    public class ApartmentListData
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
            public string as1 { get; set; }
            public string as2 { get; set; }
            public string as3 { get; set; }
            public string bjdCode { get; set; }
            public string kaptCode { get; set; }
            public string kaptName { get; set; }
        }
    }
}
