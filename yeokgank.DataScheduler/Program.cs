using System;
using yeokgank.DataScheduler.Services;
using yeokgank.DataScheduler.Services.Apartments;
using yeokgank.DataScheduler.Services.OpenDataApi;

namespace yeokgank.DataScheduler
{
    /// <summary>
    /// 국토교통부_아파트매매 실거래 상세 자료 데이터 수집 처리 [작성 중] 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("[Apartment-GetTrade]");


            string serviceKey = "yYJxEdMlDi5LRTMt6bIVZHIlAlpETrET%2F9MxDD%2BQ5EQRpWiY0VT1LKsYi7TsKOIydh%2FBuMZpWM3ZG0ZJWmr34g%3D%3D";

            /// [국토교통부_아파트매매 실거래 상세 자료]
            var tradeSet = new Settings { ServiceKey = serviceKey
                                        , PageNo = 1
                                        , Rows = 1000
                                        , StartDate = "202101"
                                        , EndDate   = "202110" };
            //OpenDataCreator.ApartmentTradeInfo(tradeSet).Execute();

            /// [국토교통부_공동주택 단지 목록제공 - 시군구 아파트 목록 수집 처리]
            var sigunguSet = new Settings { ServiceKey = serviceKey
                                           ,PageNo = 1
                                           ,Rows = 1000 };
            OpenDataCreator.ApartmentListInfo(sigunguSet).Execute();

            /// [국토교통부_아파트 기본정보 조회]
            //var basicinfoSet = new Settings { ServiceKey = serviceKey };
            //OpenDataCreator.ApartmentBasicInfo(basicinfoSet).Execute();

            /// [국토교통부_아파트 상세정보 조회]
            //var detailinfoSet = new Settings { ServiceKey = serviceKey };
            //OpenDataCreator.ApartmentDetailInfo(detailinfoSet).Execute();


            Console.ReadLine();

        }
   
        /// <summary>
        /// 간격 (초) 
        /// </summary>
        /// <param name="hour">시</param>
        /// <param name="min">분</param>
        /// <param name="interval">반복간격(초)</param>
        /// <param name="task">void:함수</param>
        static void IntervalInSeconds(int hour, int min, double interval, Action task)
        {
            interval = interval / 3600;
            Scheduler.Instance.ScheduleTask(hour, min, interval, task);
        }
        /// <summary>
        /// 간격 (분) 
        /// </summary>
        /// <param name="hour">시</param>
        /// <param name="min">분</param>
        /// <param name="interval">반복간격(분)</param>
        /// <param name="task">void:함수</param>
        static void IntervalInMinutes(int hour, int min, double interval, Action task)
        {
            interval = interval / 60;
            Scheduler.Instance.ScheduleTask(hour, min, interval, task);
        }
        /// <summary>
        /// 간격 (시간) 
        /// </summary>
        /// <param name="hour">시</param>
        /// <param name="min">분</param>
        /// <param name="interval">반복간격(시간)</param>
        /// <param name="task">void:함수</param>
        static void IntervalInHours(int hour, int min, double interval, Action task)
        {
            Scheduler.Instance.ScheduleTask(hour, min, interval, task);
        }
        /// <summary>
        /// 간격 (일) 
        /// </summary>
        /// <param name="hour">시</param>
        /// <param name="min">분</param>
        /// <param name="interval">반복간격(일)</param>
        /// <param name="task">void:함수</param>
        static void IntervalInDays(int hour, int min, double interval, Action task)
        {
            interval = interval * 24;
            Scheduler.Instance.ScheduleTask(hour, min, interval, task);
        }
    }
}
