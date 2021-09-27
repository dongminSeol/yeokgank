using System;
using yeokgank.DataScheduler.Http;
using yeokgank.DataScheduler.Services;

namespace yeokgank.DataScheduler
{
    /// <summary>
    /// 국토교통부_아파트매매 실거래 상세 자료 데이터 수집 처리 [작성 중] 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // 오전 9:00에 시작하여 1 초마다 호출됩니다.
            //IntervalInSeconds(13, 11, 1,
            //() =>
            //{
            //    Console.WriteLine($"간격(초)-{DateTime.Now.ToString("HHmmss")}");
            //});

            //string url = "http://openapi.molit.go.kr/OpenAPI_ToolInstallPackage/service/rest/RTMSOBJSvc/getRTMSDataSvcAptTradeDev";
            //url += "?ServiceKey=yYJxEdMlDi5LRTMt6bIVZHIlAlpETrET/9MxDD+Q5EQRpWiY0VT1LKsYi7TsKOIydh/BuMZpWM3ZG0ZJWmr34g==";
            //url += "&pageNo=1";
            //url += "&numOfRows=10";
            //url += "&LAWD_CD=11110";
            //url += "&DEAL_YMD=201812";

            //var http = new HttpConnecter(url);
            //var result = http.Get();
            //Console.WriteLine(result);

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
