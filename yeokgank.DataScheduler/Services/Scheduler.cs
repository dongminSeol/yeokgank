using System;
using System.Collections.Generic;
using System.Threading;

namespace yeokgank.DataScheduler.Services
{
    public class Scheduler
    {
        private Scheduler() { }
        private static Scheduler _instance;
        /// 객채가 없으면 생성
        public static Scheduler Instance => _instance ?? (_instance = new Scheduler());

        private List<Timer> timers = new List<Timer>();
        public void ScheduleTask(int hour, int min, double intervalInHour, Action task)
        {
            ///현 시간
            DateTime now = DateTime.Now;
            ///사용자 설정 작업 시작 시간
            DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);


            /// 시작 시간이 현재 시간 보다 작을 시 AddDay + 1 으로 초기화 
            if (now > firstRun)
            {
                firstRun = firstRun.AddDays(1);
            }

            /*
                timeToGo  : 지연 시간 없이 작업 하려면  TimeSpan : 0  또는 00:00:00
                firstRun(사용자 설정 시간) - now(현 시간) == 00:00:00 되면 
                timeToGo 지연 시간을 00:00:00 으로 초기화 해준다.
            */

            TimeSpan timeToGo = firstRun - now;

            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }
            var timer = new Timer(x =>
            {
                task.Invoke();
            }, null, timeToGo, TimeSpan.FromHours(intervalInHour));

            timers.Add(timer);
        }
    }
}
