using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using yeokgank.DataScheduler.Model;
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
            Console.WriteLine("[Apartment-GetTrade]");

            var apt = new Apartment();
            apt.Settings.ServiceKey = "yYJxEdMlDi5LRTMt6bIVZHIlAlpETrET%2F9MxDD%2BQ5EQRpWiY0VT1LKsYi7TsKOIydh%2FBuMZpWM3ZG0ZJWmr34g%3D%3D";
            apt.Settings.PageNo = 1;
            apt.Settings.Rows = 1000;
            apt.Settings.StartDate = "202101";
            apt.Settings.EndDate = "202110";
            apt.GetTrade();

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
