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
            Console.WriteLine("[Apartment-GetTrade]");

            // 간격(Seconds) 
            // 오전 9:00에 시작하여 5 초마다 호출됩니다.
            //IntervalInSeconds(10, 3, 5,
            //() =>
            //{
            //    Console.WriteLine($"간격(초)-{DateTime.Now.ToString("ss")}");
            //    Apartment.GetTrade();
            //});

            var apt = new Apartment(11110,-1,100);
            apt.GetTrade();




            // 간격(Days) 
            // 오전 9:00 에 시작되며 1 일마다 호출됩니다.
            //IntervalInDays(9, 0, 1,
            //() =>
            //{
            //    Console.WriteLine($"간격(날짜)-{DateTime.Now.ToString("HHmmss")}");
            //    Apartment.GetTrade();
            //});

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
