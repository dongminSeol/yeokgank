using System;
using System.Text;
using System.Threading;
using yeokgank.DataScheduler.Extensions;
using yeokgank.DataScheduler.Http;
using yeokgank.DataScheduler.Model;

namespace yeokgank.DataScheduler.Services
{
    public class Apartment
    {
        private static ApartmentTrade _apartmentTrade;
        private static bool _nextstep = false;

        static int _regionalcode;
        static int _months;
        static int _rows;

        /// <summary>
        /// [오픈API]아파트 매매 실거래 상세내역 정보
        /// </summary>
        /// <param name="regionalcode">지역코드</param>
        /// <param name="months">계약 월</param>
        /// <param name="rows">갯수 최대 1,000 개</param>
        public Apartment(int regionalcode, int months = 0, int rows = 10 )
        {
            _regionalcode = regionalcode;
            _months = months;
            _rows = rows;
        }

        public void GetTrade() 
        {
            int index = _months;

            for (int i = index; i < 1; i++)
            {
                var url = EndPoint(_regionalcode, _months, _rows);
                _nextstep = Request(url);

                if (_nextstep == true)
                {
                    AddTrade();
                }

                /// 공공데이터 API 문제로 0.01초 간격을 두고 호출
                Thread.Sleep(10);
            }
        }
        bool AddTrade() 
        {
            foreach (var i in _apartmentTrade.response.body.items.item)
            {
                Console.WriteLine($"{i.아파트.Trim()} {i.거래금액.Trim()}");
            }

            return true;
        }
        bool Request(string url) 
        {
            try
            {
                var http = new HttpConnecter(url);
                var content = http.Get<ApartmentTrade>();


                if (content == null)
                {
                    throw new Exception("Process Error. [GetTrade]");
                   
                }

                Console.WriteLine("Process Success. [GetTrade]");
                //Console.WriteLine(JsonConvert.SerializeObject(_apartmentTrade));
                _apartmentTrade = content;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Process Error. {e.Message} [GetTrade]");
                return false;
            }

        }
        string EndPoint(int regionalcode, int months = 0 ,int rows = 10)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev?", HttpDestination.TradeEndPoint.GetDescription());
            sb.AppendFormat("ServiceKey={0}&", "yYJxEdMlDi5LRTMt6bIVZHIlAlpETrET%2F9MxDD%2BQ5EQRpWiY0VT1LKsYi7TsKOIydh%2FBuMZpWM3ZG0ZJWmr34g%3D%3D");
            sb.AppendFormat("pageNo={0}&", "1");
            sb.AppendFormat("numOfRows={0}&", rows);
            sb.AppendFormat("LAWD_CD={0}&", regionalcode);
            sb.AppendFormat("DEAL_YMD={0}&", DateTime.Now.AddMonths(months).ToString("yyyyMM"));

            return sb.ToString();
        }



    }
}
